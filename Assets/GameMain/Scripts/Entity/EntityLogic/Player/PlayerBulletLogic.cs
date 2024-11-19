using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;

namespace ShootingStar
{
    public class PlayerBulletLogic : BulletLogic
    {
        private TrailRenderer trail;

        private bool isColliding;
        private float minBallisticAngle = -20f;
        private float maxBallisticAngle = 20f;
        private float ballisticAngle;
        private Vector3 targetDirection;

        protected GameObject target;
        protected EnemyEntityLoader enemyEntityLoader;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            trail = GetComponentInChildren<TrailRenderer>();
            ProcedureGame currentProcedure = GameEntry.Procedure.CurrentProcedure as ProcedureGame;
            enemyEntityLoader = currentProcedure.currentGame.enemyEntityLoader;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            isColliding = false;
            target = enemyEntityLoader.EnemyTarget();

            ballisticAngle = Random.Range(minBallisticAngle, maxBallisticAngle);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            trail.Clear();
        }

        protected override void Move()
        {
            if (!bulletData.IsOverDrive)
            {
                CachedTransform.Translate(CachedTransform.right * (bulletData.Speed * Time.deltaTime));
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    if (target != null)
                    {
                        if (target.activeSelf)
                        {
                            targetDirection = target.transform.position - transform.position;
                            CachedTransform.rotation = Quaternion.AngleAxis(
                                Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg, Vector3.forward);
                            CachedTransform.rotation *= Quaternion.Euler(0, 0, ballisticAngle);
                            CachedTransform.Translate(CachedTransform.right * (bulletData.Speed * Time.deltaTime));
                        }
                        else
                        {
                            CachedTransform.Translate(CachedTransform.right * (bulletData.Speed * Time.deltaTime));
                        }
                    }
                    else
                    {
                        CachedTransform.Translate(CachedTransform.right * (bulletData.Speed * Time.deltaTime));
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (isColliding)
            {
                return;
            }

            if (other.gameObject.TryGetComponent<EnemyFighterLogic>(out EnemyFighterLogic enemyFighterLogic))
            {
                isColliding = true;
                enemyFighterLogic.TakeDamage(bulletData.Damage);
                GameEntry.Entity.HideEntity(this);
                ReferencePool.Release(bulletData);
            }
        }
    }
}