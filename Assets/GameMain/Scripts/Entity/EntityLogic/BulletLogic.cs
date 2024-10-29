using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class BulletLogic : EntityBaseLogic
    {
        private BulletEntityData bulletData;
        
        private float timer;
        private TrailRenderer trail;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            trail = GetComponentInChildren<TrailRenderer>();
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        
            bulletData = userData as BulletEntityData;
            if (bulletData == null)
            {
                Log.Warning("WeaponData is not initialized");
            }
        
            InitData(bulletData);
            if (bulletData.Direction != Vector2.right)
            { 
                transform.GetChild(0).rotation = Quaternion.FromToRotation(Vector2.right, bulletData.Direction);
            }
        
            timer = 0;
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
        
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            trail.Clear();
        }
    }
}