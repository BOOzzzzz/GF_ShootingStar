using GameFramework;

namespace ShootingStar
{
    public class WeaponEntityData:EntityBaseData
    {
        public EntityData entityData;
        public WeaponData weaponData;

        public static WeaponEntityData Create(WeaponData weaponData,EntityData entityData)
        {
            WeaponEntityData weaponEntityData = ReferencePool.Acquire<WeaponEntityData>();
            weaponEntityData.entityData = entityData;
            weaponEntityData.weaponData = weaponData;
            return weaponEntityData;
        }
    }
}