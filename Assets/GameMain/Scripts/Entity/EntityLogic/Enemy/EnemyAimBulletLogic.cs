using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyAimBulletLogic:EnemyBulletLogic
    {
        private GameObject player;
        private Vector2 direction;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            player = GameObject.FindWithTag("Player");
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            if (player != null)
            {
                direction = (player.transform.position - transform.position).normalized;
            }
        }

        protected override void Move()
        {
            transform.Translate(direction * bulletData.Speed * Time.deltaTime);
        }
    }
}