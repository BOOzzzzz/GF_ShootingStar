using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyBulletLogic:BulletLogic
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<PlayerFighterLogic>(out PlayerFighterLogic playerFighterLogic))
            {
                playerFighterLogic.TakeDamage(bulletData.Damage);
                GameEntry.Entity.HideEntity(this);
                ReferencePool.Release(bulletData);
            }
        }
    }
}