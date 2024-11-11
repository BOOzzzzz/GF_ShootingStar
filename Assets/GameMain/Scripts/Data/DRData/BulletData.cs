// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-11 17:19:07.508
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
        /// 获取子弹方向。
        /// </summary>
        public Vector2 Direction => drBullet.Direction;


        /// <summary>
        /// 获取子弹伤害。
        /// </summary>
        public int Damage => drBullet.Damage;

    }
}