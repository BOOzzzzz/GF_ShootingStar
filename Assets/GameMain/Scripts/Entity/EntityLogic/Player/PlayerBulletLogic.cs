using System;
using GameFramework;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;

namespace ShootingStar
{
    public class PlayerBulletLogic : BulletLogic
    {
        protected TrailRenderer trail;

        protected bool isColliding;
        protected float minBallisticAngle = -20f;
        protected float maxBallisticAngle = 20f;
        protected float ballisticAngle;
        protected Vector3 targetDirection;

        protected GameObject target;
        protected EnemyEntityLoader enemyEntityLoader;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            trail = GetComponentInChildren<TrailRenderer>();
            var currentProcedure = GameEntry.Procedure.CurrentProcedure as ProcedureGame;
            enemyEntityLoader = currentProcedure!.currentGame.enemyEntityLoader;
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

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (isColliding)
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out EnemyFighterLogic enemyFighterLogic))
            {
                if (!bulletData.IsOverDrive)
                {
                    GameEntry.Event.Fire(AddEnergyEventArgs.EventId, AddEnergyEventArgs.Create(10));
                }

                GameEntry.Entity.ShowEntity<VFXLogic>(
                    VFXEntityData.Create(
                        bulletData.IsOverDrive
                            ? EnumEntity.VFXPlayerOverDriveProjectileHit
                            : EnumEntity.VFXPlayerProjectileHit,
                        collision.GetContact(0).point,
                        Quaternion.LookRotation(collision.GetContact(0).normal)
                    )
                );
                
                isColliding = true;
                enemyFighterLogic.TakeDamage(bulletData.Damage);
                GameEntry.Entity.HideEntity(this);
                ReferencePool.Release(bulletData);
            }
        }
    }
}