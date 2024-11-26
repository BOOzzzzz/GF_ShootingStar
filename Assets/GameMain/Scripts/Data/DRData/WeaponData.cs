// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-26 14:06:30.117
//------------------------------------------------------------
using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar.Data
{
    public class WeaponData 
    {
        private DRWeapon drWeapon;
        
        public WeaponData(DRWeapon drWeapon)
        {
            this.drWeapon = drWeapon;
        }
        
        public int ID
        {
             get => drWeapon.Id;
        }
        
        /// <summary>
        /// 获取子弹威力。
        /// </summary>
        public int WeaponPower => drWeapon.WeaponPower;


        /// <summary>
        /// 获取武器攻击时间间隔。
        /// </summary>
        public float AttackInterval => drWeapon.AttackInterval;


        /// <summary>
        /// 获取是否过载。
        /// </summary>
        public bool IsOverDrive => drWeapon.IsOverDrive;


        /// <summary>
        /// 获取导弹数量。
        /// </summary>
        public int MissileCount => drWeapon.MissileCount;

    }
}