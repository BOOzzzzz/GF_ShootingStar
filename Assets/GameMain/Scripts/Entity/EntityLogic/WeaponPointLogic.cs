using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class WeaponPointLogic:EntityBaseLogic
    {
        private WeaponPointData weaponPointData;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            weaponPointData = userData as WeaponPointData;
            if (weaponPointData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }
            GameEntry.Entity.AttachEntity(Entity,weaponPointData.OwnerId,"Weapon");
            InitData(weaponPointData,true);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            weaponPointData.Position = CachedTransform.position;
            weaponPointData.Rotation = CachedTransform.rotation;
        }
    }
}