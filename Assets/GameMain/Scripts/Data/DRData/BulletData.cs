// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-19 14:31:34.675
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
    public class BulletData 
    {
        private DRBullet drBullet;
        
        public BulletData(DRBullet drBullet)
        {
            this.drBullet = drBullet;
        }
        
        public int ID
        {
             get => drBullet.Id;
        }
        
        /// <summary>
        /// 获取子弹移动速度。
        /// </summary>
        public float Speed => drBullet.Speed;


        /// <summary>
        /// 获取子弹伤害。
        /// </summary>
        public int Damage => drBullet.Damage;


        /// <summary>
        /// 获取是否是过载子弹。
        /// </summary>
        public bool IsOverDirve => drBullet.IsOverDirve;

    }
}