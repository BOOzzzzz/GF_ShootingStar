using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyFighterLogic : FighterLogic
    {
        [SerializeField] private FighterEntityData enemyFighterEntityData;

        private Rigidbody rb;

        private int moveRoatationAngle = -25;
        private Vector3 targetPosition;

        private WaitForSeconds fireInterval = new WaitForSeconds(2);

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            enemyFighterEntityData = userData as FighterEntityData;
            if (enemyFighterEntityData == null)
            {
                Log.Warning("EnemyFighterData is not initialized");
            }

            rb = GetComponent<Rigidbody>();
            InitData(enemyFighterEntityData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            GameEntry.Entity.ShowEntity<ThrusterLogic>(enemyFighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<EnemyWeaponLogic>(enemyFighterEntityData.weaponEntityData);
            
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
                    enemyFighterEntityData.thrusterEntityData.Speed * Time.deltaTime)
                {
                    transform.position =
                        Vector3.MoveTowards(transform.position, targetPosition, enemyFighterEntityData.thrusterEntityData.Speed * Time.deltaTime);
                    transform.rotation =
                        Quaternion.AngleAxis((transform.position - targetPosition).normalized.y * moveRoatationAngle,
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