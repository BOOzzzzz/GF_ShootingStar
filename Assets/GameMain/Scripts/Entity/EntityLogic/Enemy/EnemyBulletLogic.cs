using GameFramework;
using UnityEngine;

namespace ShootingStar
{
    public class EnemyBulletLogic : BulletLogic
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerFighterLogic playerFighterLogic))
            {
                playerFighterLogic.TakeDamage(bulletData.Damage);
                GameEntry.Entity.HideEntity(this);
                ReferencePool.Release(bulletData);

                GameEntry.Entity.ShowEntity<VFXLogic>(VFXEntityData.Create(EnumEntity.VFXEnemyProjectileHit,
                    other.GetContact(0).point,
                    Quaternion.LookRotation(other.GetContact(0).normal))
                );
            }
        }

        protected override void Move()
        {
            transform.Translate(-CachedTransform.right * bulletData.Speed * Time.deltaTime);
        }
    }
}