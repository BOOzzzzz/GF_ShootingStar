using System;
using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class FighterEntityData : EntityBaseData
    {
        public FighterData fighterData;

        public ThrusterEntityData thrusterEntityData;
        public WeaponEntityData weaponEntityData;
        public HealthBarEntityData healthBarEntityData;
        public VFXAccessoryEntityData vfxAccessoryEntityData;

        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private float energy;
        [SerializeField] private float maxEnergy;
        [SerializeField] private int scoreBonus;

        public int ScoreBonus
        {
            get => scoreBonus;
            set => scoreBonus = value;
        }

        public float Health
        {
            get => health;
            set => health = value;
        }

        public float MaxHealth
        {
            get => maxHealth;
            private set => maxHealth = value;
        }

        public float Energy
        {
            get => energy;
            set => energy = value;
        }

        public float MaxEnergy
        {
            get => maxEnergy;
            private set => maxEnergy = value;
        }

        public static FighterEntityData Create(EnumEntity entity, EnumEntity thruster, EnumEntity weapon,
            EnumEntity health, EnumEntity vfxMuzzle)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entity, thruster, weapon, health, vfxMuzzle);
        }

        public static FighterEntityData Create(EnumEntity entity, EnumEntity thruster, EnumEntity weapon,
            EnumEntity health, EnumEntity vfxMuzzle,
            Vector3 position, Quaternion rotation)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entity, thruster, weapon, health, vfxMuzzle, position,
                rotation);
        }
        
        public static FighterEntityData Create(EnumEntity entity, EnumEntity thruster, EnumEntity weapon,
            EnumEntity health, EnumEntity vfxMuzzle,
            Vector3 position =default, Quaternion rotation =default ,Vector3 thrusterPosition = default,Quaternion thrusterRotation =default)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entity, thruster, weapon, health, vfxMuzzle, position,
                rotation , thrusterPosition , thrusterRotation);
        }

        public static FighterEntityData Create(int serialID, EnumEntity entity, EnumEntity thruster, EnumEntity weapon,
            EnumEntity health, EnumEntity vfxMuzzle,
            Vector3 position = default,
            Quaternion rotation = default, Vector3 thrusterPosition = default,Quaternion thrusterRotation =default)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(entity);
            fighterEntityData.fighterData = GameEntry.Data.GetData<FighterDatas>().GetFighterData(entity);

            fighterEntityData.Id = serialID;
            fighterEntityData.Position = position;
            fighterEntityData.Rotation = rotation;
            fighterEntityData.Health = fighterEntityData.fighterData.Health;
            fighterEntityData.MaxHealth = fighterEntityData.fighterData.MaxHealth;
            fighterEntityData.Energy = fighterEntityData.fighterData.Energy;
            fighterEntityData.MaxEnergy = fighterEntityData.fighterData.MaxEnergy;
            fighterEntityData.ScoreBonus = fighterEntityData.fighterData.ScoreBonus;
            fighterEntityData.thrusterEntityData = ThrusterEntityData.Create(thruster,
                fighterEntityData.Id, thrusterPosition,thrusterRotation);
            fighterEntityData.weaponEntityData =
                WeaponEntityData.Create(weapon, fighterEntityData.Id, (int)entity);
            fighterEntityData.healthBarEntityData = HealthBarEntityData.Create(health, fighterEntityData.Id);
            fighterEntityData.vfxAccessoryEntityData = VFXAccessoryEntityData.Create(vfxMuzzle, fighterEntityData.Id);

            return fighterEntityData;
        }
    }
}