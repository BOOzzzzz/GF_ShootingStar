using System.Collections;
using GameFramework;
using GameFramework.Event;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyFighterLogic : FighterLogic
    {
        private bool isPlayerDead = false;

        private Vector3 targetPosition;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            fighterEntityData = userData as FighterEntityData;
            if (fighterEntityData == null)
            {
                Log.Warning("EnemyFighterData is not initialized");
            }

            InitData(fighterEntityData);
        }

        private void OnPlayerDead(object sender, GameEventArgs e)
        {
            GameOverEventArgs args = e as GameOverEventArgs;
            if (args == null)
            {
                return;
            }
            
            isPlayerDead = true;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            GameEntry.Event.Subscribe(GameOverEventArgs.EventId, OnPlayerDead);

            GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<EnemyWeaponLogic>(fighterEntityData.weaponEntityData);
            GameEntry.Entity.ShowEntity<HealthBarLogic>(HealthBarEntityData.Create(EnumEntity.EnemyHealthBar,transform));

            targetPosition = RandomPosition();
            StartCoroutine(nameof(RandomMove));
            StartCoroutine(nameof(RandomFire));
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            GameEntry.Event.Unsubscribe(GameOverEventArgs.EventId, OnPlayerDead);
            StopAllCoroutines();
        }

        protected override void OnDead()
        {
            GameEntry.Event.Fire(this,EnemyDieEventArgs.Create(this));
            ReferencePool.Release(fighterEntityData);
        }

        private IEnumerator RandomFire()
        {
            while (!isPlayerDead)
            {
                yield return fireInterval;
                weapon.Attack();
            }
        }

        private IEnumerator RandomMove()
        {
            while (gameObject.activeSelf)
            {
                if (Vector3.Distance(transform.position, targetPosition) >
                    fighterEntityData.thrusterEntityData.Speed * Time.deltaTime)
                {
                    transform.position =
                        Vector3.MoveTowards(transform.position, targetPosition,
                            fighterEntityData.thrusterEntityData.Speed * Time.deltaTime);
                    transform.rotation =
                        Quaternion.AngleAxis((transform.position - targetPosition).normalized.y * -angelRotate,
                            Vector3.right);
                }
                else
                {
                    targetPosition = RandomPosition();
                }

                yield return null;
            }
        }

        private Vector3 RandomPosition()
        {
            float posX = Random.Range(0, EntityExtension.MaxHorizontalDistance);
            float posY = Random.Range(EntityExtension.MinVerticalDistance, EntityExtension.MaxVerticalDistance);
            return new Vector3(posX, posY, 0);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            if (childEntity is EnemyWeaponLogic)
            {
                weapon = childEntity as EnemyWeaponLogic;
            }
        }
    }
}