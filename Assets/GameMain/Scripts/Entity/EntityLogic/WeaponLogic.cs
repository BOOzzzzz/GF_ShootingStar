using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class WeaponLogic : EntityBaseLogic
    {
        private WeaponData weaponData;

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

            weaponData = userData as WeaponData;
            if (weaponData == null)
            {
                Log.Warning("WeaponData is not initialized");
            }

            InitData(weaponData, false);
            Log.Debug(weaponData.Direction);
            if (weaponData.Direction != Vector2.right)
            { 
                transform.GetChild(0).rotation = Quaternion.FromToRotation(Vector2.right, weaponData.Direction);
            }

            timer = 0;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            transform.Translate(weaponData.Direction * weaponData.Speed * elapseSeconds);

            timer += Time.deltaTime;
            if (timer > 4)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            trail.Clear();
        }
    }
}