using System;
using GameFramework;
using ShootingStar.DataTableData;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class BulletEntityData:EntityBaseData
    {
        public EntityData entityData;
        public BulletData bulletData;

        public static BulletEntityData Create(BulletData bulletData,EntityData entityData)
        {
            BulletEntityData bulletEntityData = ReferencePool.Acquire<BulletEntityData>();
            bulletEntityData.entityData = entityData;
            bulletEntityData.bulletData = bulletData;
            return bulletEntityData;
        }
        
        public static BulletEntityData Create(EnumEntity id)
        {
            return Create(GameEntry.Entity.GenerateSerialId(),id);
        }
        
        public static BulletEntityData Create(EnumEntity id , Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(),id,position);
        }
        
        public static BulletEntityData Create(int serialID, EnumEntity id)
        {
            BulletEntityData bulletEntityData = ReferencePool.Acquire<BulletEntityData>();
            bulletEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            bulletEntityData.bulletData = GameEntry.Data.GetData<BulletDatas>().GetBulletData(id);

            bulletEntityData.Id = serialID;
            bulletEntityData.Speed = bulletEntityData.bulletData.Speed;
            bulletEntityData.Attack = bulletEntityData.bulletData.Attack;
            bulletEntityData.AttackInterval = bulletEntityData.bulletData.AttackInterval;
            bulletEntityData.Direction = bulletEntityData.bulletData.Direction;
            return bulletEntityData;
        }
        
        public static BulletEntityData Create(int serialID, EnumEntity id ,Vector3 position)
        {
            BulletEntityData bulletEntityData = ReferencePool.Acquire<BulletEntityData>();
            bulletEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            bulletEntityData.bulletData = GameEntry.Data.GetData<BulletDatas>().GetBulletData(id);

            bulletEntityData.Id = serialID;
            bulletEntityData.Speed = bulletEntityData.bulletData.Speed;
            bulletEntityData.Attack = bulletEntityData.bulletData.Attack;
            bulletEntityData.AttackInterval = bulletEntityData.bulletData.AttackInterval;
            bulletEntityData.Direction = bulletEntityData.bulletData.Direction;
            bulletEntityData.Position = position;
            return bulletEntityData;
        }

        public Vector2 Direction { get; set; }

        public float AttackInterval { get; set; }

        public int Attack { get; set; }

        public float Speed { get; set; }
    }
}