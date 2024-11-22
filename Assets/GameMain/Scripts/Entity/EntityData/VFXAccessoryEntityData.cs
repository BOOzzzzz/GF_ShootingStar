using System;
using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class VFXAccessoryEntityData : AccessoryObjectData
    {


        public static VFXAccessoryEntityData Create(EnumEntity id, int ownerId)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId);
        }

        public static VFXAccessoryEntityData Create(EnumEntity id, int ownerId, Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId, position);
        }

        public static VFXAccessoryEntityData Create(int serialID, EnumEntity id, int ownerId, Vector3 postion = default,
            Quaternion rotation = default)
        {
            VFXAccessoryEntityData vfxAccessoryEntityData = ReferencePool.Acquire<VFXAccessoryEntityData>();
            vfxAccessoryEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);

            vfxAccessoryEntityData.Id = serialID;
            vfxAccessoryEntityData.Position = postion;
            vfxAccessoryEntityData.Rotation = rotation;
            vfxAccessoryEntityData.OwnerId = ownerId;
            return vfxAccessoryEntityData;
        }
    }
}