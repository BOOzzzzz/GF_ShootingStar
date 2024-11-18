using System.Collections;
using UnityEngine;

namespace ShootingStar
{
    public abstract class PlayerTraceableBulletLogic : PlayerBulletLogic
    {
        float minBallisticAngle = -50f;
        float maxBallisticAngle = 50f;
        float ballisticAngle;
        Vector3 targetDirection;

        protected GameObject target;
        protected EnemyEntityLoader enemyEntityLoader;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            ProcedureGame currentProcedure = GameEntry.Procedure.CurrentProcedure as ProcedureGame;
            enemyEntityLoader = currentProcedure.currentGame.enemyEntityLoader;
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            target = enemyEntityLoader.EnemyTarget();
            if (target != null)
            {
                StartCoroutine(HomingCoroutine(target));
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            StopAllCoroutines();
        }

        public IEnumerator HomingCoroutine(GameObject targetEntity)
        {
            ballisticAngle = Random.Range(minBallisticAngle, maxBallisticAngle);
            while (gameObject.activeSelf)
            {
                if (targetEntity.activeSelf)
                {
                    targetDirection = targetEntity.transform.position - transform.position;
                    transform.rotation =
                        Quaternion.AngleAxis(Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg,
                            Vector3.forward);
                    transform.rotation *= Quaternion.Euler(0, 0, ballisticAngle);
                    Move();
                }
                else
                {
                    Move();
                }

                yield return null;
            }
        }
    }
}