﻿using System;
using GameFramework;
using ShootingStar.DataTableData;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootingStar
{
    [Serializable]
    public class FighterEntityData : EntityBaseData
    {
        public FighterData fighterData;

        public ThrusterEntityData thrusterEntityData;
        public WeaponEntityData weaponEntityData;

        [SerializeField] private int health;

        public int Health
        {
            get => health;
            set => health = value;
        }

        public static FighterEntityData Create(EnumEntity entity, EnumEntity thruster, EnumEntity weapon)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entity, thruster, weapon);
        }

        public static FighterEntityData Create(EnumEntity entity, EnumEntity thruster, EnumEntity weapon,
            Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entity, thruster, weapon, position);
        }

        public static FighterEntityData Create(EnumEntity entity, EnumEntity thruster, EnumEntity weapon,
            Vector3 position, Quaternion rotation)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entity, thruster, weapon, position, rotation);
        }

        public static FighterEntityData Create(int serialID, EnumEntity entity, EnumEntity thruster, EnumEntity weapon,
            Vector3 position = default,
            Quaternion rotation = default)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(entity);
            fighterEntityData.fighterData = GameEntry.Data.GetData<FighterDatas>().GetFighterData(entity);

            fighterEntityData.Id = serialID;
            fighterEntityData.Position = position;
            fighterEntityData.Rotation = rotation;
            fighterEntityData.Health = fighterEntityData.fighterData.Health;
            fighterEntityData.thrusterEntityData = ThrusterEntityData.Create(thruster,
                fighterEntityData.Id, new Vector3(0, 0, 0));
            fighterEntityData.weaponEntityData =
                WeaponEntityData.Create(weapon, fighterEntityData.Id, new Vector3(0, 0, 0));

            return fighterEntityData;
        }
    }
}