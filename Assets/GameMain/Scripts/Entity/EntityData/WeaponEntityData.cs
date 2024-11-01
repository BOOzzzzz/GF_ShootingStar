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
        private float attackInterval;

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

        public static WeaponEntityData Create(EnumEntity id, int ownerId)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId);
        }

        public static WeaponEntityData Create(EnumEntity id, int ownerId, Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId, position);
        }

        public static WeaponEntityData Create(int serialID, EnumEntity id, int ownerId, Vector3 postion = default,
            Quaternion rotation = default)
        {
            WeaponEntityData weaponEntityData = ReferencePool.Acquire<WeaponEntityData>();
            weaponEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            weaponEntityData.weaponData = GameEntry.Data.GetData<WeaponDatas>().GetWeaponData(id);

            weaponEntityData.Id = serialID;
            weaponEntityData.Position = postion;
            weaponEntityData.Rotation = rotation;
            weaponEntityData.OwnerId = ownerId;
            weaponEntityData.WeaponPower = weaponEntityData.weaponData.WeaponPower;
            weaponEntityData.AttackInterval = weaponEntityData.weaponData.AttackInterval;
            return weaponEntityData;
        }
    }
}