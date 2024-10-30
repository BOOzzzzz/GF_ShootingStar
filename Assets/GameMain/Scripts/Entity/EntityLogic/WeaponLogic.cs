using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class WeaponLogic : EntityBaseLogic
    {
        protected WeaponEntityData weaponData;

        private Transform middleMuzzle;
        private Transform topMuzzle;
        private Transform bottomMuzzle;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            weaponData = userData as WeaponEntityData;
            if (weaponData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }

            GameEntry.Entity.AttachEntity(Entity, weaponData.OwnerId, "Weapon");
            InitData(weaponData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            weaponData.Position = CachedTransform.position;
            weaponData.Rotation = CachedTransform.rotation;
        }

        public abstract void Attack();

    }
}