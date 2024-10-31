// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-10-31 23:31:18.031
//------------------------------------------------------------
using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class ThrusterData 
    {
        private DRThruster drThruster;
        
        public ThrusterData(DRThruster drThruster)
        {
            this.drThruster = drThruster;
        }
        
        public int ID
        {
             get => drThruster.Id;
        }
        
        /// <summary>
        /// 获取推进器速度。
        /// </summary>
        public int Speed => drThruster.Speed;

    }
}