﻿using System;
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
        
        [SerializeField]private float changeTime;
        public float ChangeTime
        {
            get => changeTime;
            set => changeTime = value;
        }

        public static FighterEntityData Create(EnumEntity id)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id);
        }

        public static FighterEntityData Create(int serialID, EnumEntity id)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            fighterEntityData.fighterData = GameEntry.Data.GetData<FighterDatas>().GetFighterData(id);

            fighterEntityData.Id = serialID;
            fighterEntityData.ChangeTime = fighterEntityData.fighterData.ChangeTime;
            fighterEntityData.thrusterEntityData =
                ThrusterEntityData.Create(EnumEntity.ThrusterPoint, fighterEntityData.Id);
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