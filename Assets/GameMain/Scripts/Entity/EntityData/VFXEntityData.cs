using System;
using GameFramework;
using ShootingStar.Data;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    [Serializable]
    public class VFXEntityData : EntityBaseData
    {
        private Entity ownerEntity;

        public Entity OwnerEntity
        {
            get => ownerEntity;
            set => ownerEntity = value;
        }

        public static VFXEntityData Create(EnumEntity id)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id);
        }

        public static VFXEntityData Create(EnumEntity id, Vector3 position, Quaternion rotation)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, position, rotation);
        }

        public static VFXEntityData Create(EnumEntity id, Vector3 position, Quaternion rotation, Entity owner)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, position, rotation, owner);
        }


        public static VFXEntityData Create(int serialID, EnumEntity id, Vector3 position = default,
            Quaternion rotation = default, Entity owner = default)
        {
            VFXEntityData vfxEntityData = ReferencePool.Acquire<VFXEntityData>();
            vfxEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);

            vfxEntityData.Id = serialID;
            vfxEntityData.Position = position;
            vfxEntityData.Rotation = rotation;
            vfxEntityData.OwnerEntity = owner;
            return vfxEntityData;
        }
    }
}