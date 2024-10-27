using GameFramework;

namespace ShootingStar
{
    public class WeaponEntityData:EntityBaseData
    {
        public EntityData entityData;
        public BulletData BulletData;

        public static WeaponEntityData Create(BulletData bulletData,EntityData entityData)
        {
            WeaponEntityData weaponEntityData = ReferencePool.Acquire<WeaponEntityData>();
            weaponEntityData.entityData = entityData;
            weaponEntityData.BulletData = bulletData;
            return weaponEntityData;
        }
    }
}