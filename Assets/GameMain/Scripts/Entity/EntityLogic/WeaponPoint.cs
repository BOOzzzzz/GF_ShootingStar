using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class WeaponPoint:EntityBaseLogic
    {
        private WeaponPointData _weaponPointData;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            _weaponPointData = userData as WeaponPointData;
            if (_weaponPointData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }
            GameEntry.Entity.AttachEntity(Entity,_weaponPointData.OwnerId,"Weapon");
            InitData(_weaponPointData);
        }
    }
}