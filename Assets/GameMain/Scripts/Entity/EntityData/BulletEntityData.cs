using System;
using GameFramework;
using ShootingStar.Data;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class BulletEntityData : EntityBaseData
    {
        public BulletData bulletData;
        
        private Vector2 direction;
        private int attack;
        private float speed;
        private int damage;

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        public Vector2 Direction
        {
            get => direction;
            set => direction = value;
        }

        public int Attack
        {
            get => attack;
            set => attack = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public static BulletEntityData Create(EnumEntity id)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id);
        }

        public static BulletEntityData Create(EnumEntity id, Vector3 position)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, position);
        }

        public static BulletEntityData Create(EnumEntity id, Vector3 position, Quaternion rotation)
        {
            return Create(GameEntry.Entity.GenerateSerialId(), id, position, rotation);
        }

        public static BulletEntityData Create(int serialID, EnumEntity id, Vector3 position = default,
            Quaternion rotation = default)
        {
            BulletEntityData bulletEntityData = ReferencePool.Acquire<BulletEntityData>();
            bulletEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            bulletEntityData.bulletData = GameEntry.Data.GetData<BulletDatas>().GetBulletData(id);

            bulletEntityData.Id = serialID;
            bulletEntityData.Position = position;
            bulletEntityData.Rotation = rotation;
            bulletEntityData.Speed = bulletEntityData.bulletData.Speed;
            bulletEntityData.Attack = bulletEntityData.bulletData.Attack;
            bulletEntityData.Direction = bulletEntityData.bulletData.Direction;
            bulletEntityData.Damage = bulletEntityData.bulletData.Damage;
            return bulletEntityData;
        }
    }
}