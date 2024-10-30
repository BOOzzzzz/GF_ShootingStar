using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    public class BulletData
    {
        private DRBullet drBullet;

        public BulletData(DRBullet drBullet)
        {
            this.drBullet=drBullet;
        }

        public int ID
        {
            get => drBullet.Id;
        }

        public int Attack
        {
            get => drBullet.Attack;
        }

        public float Speed
        {
            get => drBullet.Speed;
        }

        public Vector2 Direction
        {
            get => drBullet.Direction;
        }
    }
}