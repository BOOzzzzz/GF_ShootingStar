using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerBulletLogic:BulletLogic
    {
        private TrailRenderer trail;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            trail = GetComponentInChildren<TrailRenderer>();
        }
        
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            trail.Clear();
        }
    }
}