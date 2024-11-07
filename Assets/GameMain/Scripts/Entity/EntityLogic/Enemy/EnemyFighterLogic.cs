using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyFighterLogic : FighterLogic
    {
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

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<EnemyWeaponLogic>(fighterEntityData.weaponEntityData);
            
            targetPosition = RandomPosition();
            StartCoroutine(nameof(RandomMove));
            StartCoroutine(nameof(RandomFire));
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            
            StopAllCoroutines();
        }

        private IEnumerator RandomFire()
        {
            while (gameObject.activeSelf)
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
                        Vector3.MoveTowards(transform.position, targetPosition, fighterEntityData.thrusterEntityData.Speed * Time.deltaTime);
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
            float posX = Random.Range(0, EntityExtension.maxHorizontalDistance);
            float posY = Random.Range(EntityExtension.minVerticalDistance, EntityExtension.maxVerticalDistance);
            return new Vector3(posX, posY,0);
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