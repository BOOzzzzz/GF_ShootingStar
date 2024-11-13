// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-13 11:13:20.656
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
    public class FighterData 
    {
        private DRFighter drFighter;
        
        public FighterData(DRFighter drFighter)
        {
            this.drFighter = drFighter;
        }
        
        public int ID
        {
             get => drFighter.Id;
        }
        
        /// <summary>
        /// 获取生命值。
        /// </summary>
        public float Health => drFighter.Health;


        /// <summary>
        /// 获取最大生命值。
        /// </summary>
        public float MaxHealth => drFighter.MaxHealth;

    }
}