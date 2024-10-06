using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class WeaponLogic:EntityBaseLogic
    {
        private WeaponData weaponData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            weaponData = userData as WeaponData;
            if (weaponData == null)
            {
                Log.Warning("WeaponData is not initialized");
            }
            
            InitData(weaponData,false);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            
            transform.Translate(Vector3.right * weaponData.Speed * elapseSeconds);
        }
    }
}