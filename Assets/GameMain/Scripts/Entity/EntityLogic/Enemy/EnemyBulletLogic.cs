using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyBulletLogic:BulletLogic
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameEntry.Entity.HideEntity(bulletData.Id);
            }
        }
    }
}