using GameFramework;

namespace ShootingStar.ReferencePoolData
{
    public class WeaponEntityData:EntityBaseData
    {
        public EntityData entityData;
        public WeaponData weaponData;

        public WeaponEntityData Create(WeaponData weaponData,EntityData entityData)
        {
            WeaponEntityData weaponEntityData = ReferencePool.Acquire<WeaponEntityData>();
            weaponEntityData.entityData = entityData;
            weaponEntityData.weaponData = weaponData;
            return weaponEntityData;
        }
    }
}