using System;
using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class WeaponEntityData : AccessoryObjectData
    {
        public WeaponData weaponData;
        [SerializeField] private int weaponPower;
        [SerializeField] private float attackInterval;
        [SerializeField] private bool isOverDrive;
        [SerializeField] private int missileCount;

        public int WeaponPower
        {
            get => weaponPower;
            set => weaponPower = value;
        }

        public float AttackInterval
        {
            get => attackInterval;
            set => attackInterval = value;
        }

        public bool IsOverDrive
        {
            get => isOverDrive;
            set => isOverDrive = value;
        }

        public int MissileCount
        {
            get => missileCount;
            set => missileCount = value;
        }

        public static WeaponEntityData Create(EnumEntity id, int ownerId, int ownerEntityId)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId, ownerEntityId);
        }

        public static WeaponEntityData Create(EnumEntity id, int ownerId, int ownerEntityId, Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId, ownerEntityId, position);
        }

        public static WeaponEntityData Create(int serialID, EnumEntity id, int ownerId, int ownerEntityId,
            Vector3 postion = default,
            Quaternion rotation = default)
        {
            WeaponEntityData weaponEntityData = ReferencePool.Acquire<WeaponEntityData>();
            weaponEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            weaponEntityData.weaponData = GameEntry.Data.GetData<WeaponDatas>().GetWeaponData(id);

            weaponEntityData.Id = serialID;
            weaponEntityData.Position = postion;
            weaponEntityData.Rotation = rotation;
            weaponEntityData.OwnerId = ownerId;
            weaponEntityData.OwnerEntityId = ownerEntityId;
            weaponEntityData.WeaponPower = weaponEntityData.weaponData.WeaponPower;
            weaponEntityData.AttackInterval = weaponEntityData.weaponData.AttackInterval;
            weaponEntityData.IsOverDrive = weaponEntityData.weaponData.IsOverDrive;
            weaponEntityData.MissileCount = weaponEntityData.weaponData.MissileCount;
            return weaponEntityData;
        }
    }
}