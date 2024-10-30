using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    public class WeaponData
    {
        private DRWeapon drWeapon;

        public WeaponData(DRWeapon drWeapon)
        {
            this.drWeapon=drWeapon;
        }

        public int ID
        {
            get => drWeapon.Id;
        }

        public int WeaponPower
        {
            get => drWeapon.WeaponPower;
        }

        public float AttackInterval
        {
            get => drWeapon.AttackInterval;
        }
    }
}