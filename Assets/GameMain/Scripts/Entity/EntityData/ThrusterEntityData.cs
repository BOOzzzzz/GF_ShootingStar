using System;
using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class ThrusterEntityData : AccessoryObjectData
    {
        public ThrusterData thrusterData;

        [SerializeField] private float speed;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public static ThrusterEntityData Create(EnumEntity id, int ownerId)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId);
        }

        public static ThrusterEntityData Create(EnumEntity id, int ownerId, Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, ownerId, position);
        }

        public static ThrusterEntityData Create(int serialID, EnumEntity id, int ownerId, Vector3 postion = default,
            Quaternion rotation = default)
        {
            ThrusterEntityData thrusterEntityData = ReferencePool.Acquire<ThrusterEntityData>();
            thrusterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            thrusterEntityData.thrusterData = GameEntry.Data.GetData<ThrusterDatas>().GetThrusterData(id);

            thrusterEntityData.Id = serialID;
            thrusterEntityData.Position = postion;
            thrusterEntityData.Rotation = rotation;
            thrusterEntityData.OwnerId = ownerId;
            thrusterEntityData.Speed = thrusterEntityData.thrusterData.Speed;
            return thrusterEntityData;
        }
    }
}