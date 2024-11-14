// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-14 15:11:34.871
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
        /// 获取武器威力。
        /// </summary>
        public int WeaponPower => drWeapon.WeaponPower;


        /// <summary>
        /// 获取武器攻击时间间隔。
        /// </summary>
        public float AttackInterval => drWeapon.AttackInterval;


        /// <summary>
        /// 获取是否超速。
        /// </summary>
        public bool IsOverDrive => drWeapon.IsOverDrive;

    }
}