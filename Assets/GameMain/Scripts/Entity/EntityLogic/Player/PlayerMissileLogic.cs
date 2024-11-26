using System;
using GameFramework;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;

namespace ShootingStar
{
    public class PlayerMissileLogic : PlayerBulletLogic
    {
        Collider2D[] colliders = new Collider2D[10];

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void Move()
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
                    GameEntry.Entity.HideEntity(this);
                }
            }
        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            if (isColliding)
            {
                return;
            }

            GameEntry.Entity.ShowEntity<VFXLogic>(VFXEntityData.Create(EnumEntity.VFXMissileExplosion,
                CachedTransform.position, CachedTransform.rotation));
            int num = Physics2D.OverlapCircleNonAlloc(transform.position, 2.25f, colliders, LayerMask.GetMask("Enemy"));
            
            for (int i = 0; i < num; i++)
            {
                if (colliders[i].TryGetComponent(out EnemyFighterLogic enemyFighterLogic))
                {
                    enemyFighterLogic.TakeDamage(bulletData.Damage);
                }
            }

            isColliding = true;
            GameEntry.Entity.HideEntity(this);
            ReferencePool.Release(bulletData);
        }
    }
}