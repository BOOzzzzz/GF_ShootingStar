using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    public class BulletData
    {
        private DRBullet drWeapon;

        public BulletData(DRBullet drWeapon)
        {
            this.drWeapon=drWeapon;
        }

        public int ID
        {
            get => drWeapon.Id;
        }

        public int Attack
        {
            get => drWeapon.Attack;
        }

        public float AttackInterval
        {
            get => drWeapon.AttackInterval;
        }

        public float Speed
        {
            get => drWeapon.Speed;
        }
    }
}