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
        private bool isPlayerDead;
        private bool isDead;

        private Vector3 targetPosition;
        
        protected MuzzleVFXLogic muzzleVFXLogic;

        protected override void OnShow(object userData)
        {

            fighterEntityData = userData as FighterEntityData;
            if (fighterEntityData == null)
            {
                Log.Warning("EnemyFighterData is not initialized");
                return;
            }

            InitData(fighterEntityData);
            
            base.OnShow(userData);

            GameEntry.Event.Subscribe(GameOverEventArgs.EventId, OnPlayerDead);

            targetPosition = RandomPosition();
            StartCoroutine(nameof(RandomMove));
            StartCoroutine(nameof(RandomFire));

            isDead = false;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            GameEntry.Event.Unsubscribe(GameOverEventArgs.EventId, OnPlayerDead);
            StopAllCoroutines();
        }

        public override void ShowEntity()
        {
            GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<EnemyWeaponLogic>(fighterEntityData.weaponEntityData);
            GameEntry.Entity.ShowEntity<HealthBarLogic>(fighterEntityData.healthBarEntityData);
            GameEntry.Entity.ShowEntity<MuzzleVFXLogic>(fighterEntityData.vfxAccessoryEntityData);
        }

        protected override void OnDead()
        {
            if (isDead)
            {
                return;
            }
            isDead = true;
            base.OnDead();
            GameEntry.Event.Fire(this, EnemyDieEventArgs.Create(this));
            
            GameEntry.Entity.ShowEntity<VFXLogic>(VFXEntityData.Create(EnumEntity.VFXEnemyDeath,CachedTransform.position,CachedTransform.rotation));
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

        private IEnumerator RandomFire()
        {
            while (!isPlayerDead)
            {
                yield return fireInterval;
                muzzleVFXLogic.muzzleParticleSystem.Play();
                weaponLogic.Attack();
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

            if (childEntity is EnemyWeaponLogic enemyWeaponLogic)
            {
                weaponLogic = enemyWeaponLogic;
            }
            
            if (childEntity is MuzzleVFXLogic enemyMuzzleVFXLogic)
            {
                muzzleVFXLogic = enemyMuzzleVFXLogic;
            }
        }
    }
}