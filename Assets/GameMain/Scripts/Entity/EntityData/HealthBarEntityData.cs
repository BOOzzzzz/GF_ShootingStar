using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    public class HealthBarEntityData : EntityBaseData
    {
        private int followID;

        public int FollowID
        {
            get => followID;
            set => followID = value;
        }

        public static HealthBarEntityData Create(EnumEntity entityData, int follow, Vector3 position = default,
            Quaternion rotation = default)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entityData, follow, position, rotation);
        }

        public static HealthBarEntityData Create(int serialID, EnumEntity entityData, int follow,
            Vector3 position = default,
            Quaternion rotation = default)
        {
            HealthBarEntityData healthBarEntityData = ReferencePool.Acquire<HealthBarEntityData>();
            healthBarEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(entityData);

            healthBarEntityData.Id = serialID;
            healthBarEntityData.Position = position;
            healthBarEntityData.Rotation = rotation;
            healthBarEntityData.FollowID = follow;

            return healthBarEntityData;
        }
    }
}