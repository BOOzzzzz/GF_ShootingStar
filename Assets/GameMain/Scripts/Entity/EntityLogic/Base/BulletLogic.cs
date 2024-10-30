using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class BulletLogic : EntityBaseLogic
    {
        private float timer;
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
            
            if (bulletData.Direction != Vector2.right)
            { 
                transform.GetChild(0).rotation = Quaternion.FromToRotation(Vector2.right, bulletData.Direction);
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            
            transform.Translate(bulletData.Direction * bulletData.Speed * elapseSeconds);
        
            timer += Time.deltaTime;
            if (timer > 4)
            {
                GameEntry.Entity.HideEntity(this);
                ReferencePool.Release(bulletData);
            }
        }
    }
}