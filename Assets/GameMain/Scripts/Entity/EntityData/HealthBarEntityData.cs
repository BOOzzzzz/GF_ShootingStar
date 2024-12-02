using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    public class HealthBarEntityData : EntityBaseData
    {
        private int followID;
        private float offset;

        public int FollowID
        {
            get => followID;
            set => followID = value;
        }
        
        public float Offset
        {
            get => offset;
            set => offset = value;
        }

        public static HealthBarEntityData Create(EnumEntity entityData, int follow,float offset , Vector3 position = default,
            Quaternion rotation = default)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), entityData, follow,offset, position, rotation);
        }

        public static HealthBarEntityData Create(int serialID, EnumEntity entityData, int follow,float offset,
            Vector3 position = default,
            Quaternion rotation = default)
        {
            HealthBarEntityData healthBarEntityData = ReferencePool.Acquire<HealthBarEntityData>();
            healthBarEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(entityData);

            healthBarEntityData.Id = serialID;
            healthBarEntityData.Position = position;
            healthBarEntityData.Rotation = rotation;
            healthBarEntityData.FollowID = follow;
            healthBarEntityData.Offset = offset;

            return healthBarEntityData;
        }
    }
}