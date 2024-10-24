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

        public static FighterEntityData Create(EnumEntity id)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            fighterEntityData.fighterData = GameEntry.Data.GetData<FighterDatas>().GetFighterData(id);

            fighterEntityData.Id = EntityExtension.serialID;
            fighterEntityData.thrusterEntityData=ThrusterEntityData.Create(EnumEntity.ThrusterPoint,fighterEntityData.Id);
            return fighterEntityData;
        }

        public static FighterEntityData Create(EnumEntity id, Vector3 position, Quaternion rotation)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            fighterEntityData.fighterData = GameEntry.Data.GetData<FighterDatas>().GetFighterData(id);

            fighterEntityData.Position = position;
            fighterEntityData.Rotation = rotation;

            return fighterEntityData;
        }
    }
}