using System.Collections;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class BulletLogic : AutoDisableEntityLogic
    {
        [SerializeField]
        protected BulletEntityData bulletData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        
            bulletData = userData as BulletEntityData;
            if (bulletData == null)
            {
                Log.Warning("BulletData is not initialized");
            }
        
            InitData(bulletData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            
            Move();
        }

        protected abstract void Move();

        protected override void Release()
        {
            ReferencePool.Release(bulletData);
        }
    }
}