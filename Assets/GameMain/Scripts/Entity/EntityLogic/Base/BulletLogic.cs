﻿using System;
using System.Collections;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class BulletLogic : EntityBaseLogic
    {
        protected BulletEntityData bulletData;

        private WaitForSeconds disabledTime = new WaitForSeconds(4);
        
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

            StartCoroutine(nameof(AutoDisabled));
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            
            transform.Translate(bulletData.Direction * bulletData.Speed * elapseSeconds);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            
            StopAllCoroutines();
        }

        private IEnumerator AutoDisabled()
        {
            yield return disabledTime;
            GameEntry.Entity.HideEntity(this);
            ReferencePool.Release(bulletData);
        }
    }
}