using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerBulletLogic:BulletLogic
    {
        private TrailRenderer trail;

        private bool isColliding;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            trail = GetComponentInChildren<TrailRenderer>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            isColliding = false;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            trail.Clear();
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