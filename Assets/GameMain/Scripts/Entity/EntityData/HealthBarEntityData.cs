using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    public class HealthBarEntityData : EntityBaseData
    {
        public Transform follow;

        public Transform Follow
        {
            get => follow;
            set => follow = value;
        }

        public static HealthBarEntityData Create(EnumEntity entityData, Transform follow, Vector3 position = default,
            Quaternion rotation = default)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entityData, follow, position, rotation);
        }

        public static HealthBarEntityData Create(int serialID, EnumEntity entityData, Transform follow,
            Vector3 position = default,
            Quaternion rotation = default)
        {
            HealthBarEntityData healthBarEntityData = ReferencePool.Acquire<HealthBarEntityData>();
            healthBarEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(entityData);

            healthBarEntityData.Id = serialID;
            healthBarEntityData.Position = position;
            healthBarEntityData.Rotation = rotation;
            healthBarEntityData.follow = follow;

            return healthBarEntityData;
        }
    }
}