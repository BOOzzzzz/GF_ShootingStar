using System;
using GameFramework;
using ShootingStar.DataTableData;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class FighterEntityData : EntityBaseData
    {
        public EntityData entityData;
        public FighterData fighterData;

        public ThrusterEntityData thrusterEntityData;
        public WeaponEntityData weaponEntityData;

        [SerializeField] private float changeTime;

        public float ChangeTime
        {
            get => changeTime;
            set => changeTime = value;
        }

        public static FighterEntityData Create(EnumEntity id)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id);
        }

        public static FighterEntityData Create(EnumEntity id, Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, position);
        }

        public static FighterEntityData Create(EnumEntity id, Vector3 position, Quaternion rotation)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, position, rotation);
        }

        public static FighterEntityData Create(int serialID, EnumEntity id, Vector3 position = default,
            Quaternion rotation = default)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            fighterEntityData.fighterData = GameEntry.Data.GetData<FighterDatas>().GetFighterData(id);

            fighterEntityData.Id = serialID;
            fighterEntityData.Position = position;
            fighterEntityData.Rotation = rotation;
            fighterEntityData.ChangeTime = fighterEntityData.fighterData.ChangeTime;
            fighterEntityData.thrusterEntityData = ThrusterEntityData.Create(EnumEntity.ThrusterPoint,
                fighterEntityData.Id, new Vector3(0, 0, 0));
            fighterEntityData.weaponEntityData =
                WeaponEntityData.Create(EnumEntity.WeaponPoint, fighterEntityData.Id, new Vector3(0, 0, 0));

            return fighterEntityData;
        }
    }
}