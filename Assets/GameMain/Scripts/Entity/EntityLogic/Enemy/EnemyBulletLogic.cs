using GameFramework;
using UnityEngine;

namespace ShootingStar
{
    public class EnemyBulletLogic:BulletLogic
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerFighterLogic playerFighterLogic))
            {
                playerFighterLogic.TakeDamage(bulletData.Damage);
                GameEntry.Entity.HideEntity(this);
                ReferencePool.Release(bulletData);
            }
        }

        protected override void Move()
        {
            transform.Translate(-CachedTransform.right * bulletData.Speed * Time.deltaTime);
        }
    }
}