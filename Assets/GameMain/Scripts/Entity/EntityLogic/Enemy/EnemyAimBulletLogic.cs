using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyAimBulletLogic:EnemyBulletLogic
    {
        private GameObject player;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            player = GameObject.FindWithTag("Player");
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            bulletData.Direction = (player.transform.position - transform.position).normalized;
        }

        protected override void Move(float elapseSeconds)
        {
            
            base.Move(elapseSeconds);
        }
    }
}