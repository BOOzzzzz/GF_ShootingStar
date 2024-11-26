// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-26 14:06:30.116
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


        /// <summary>
        /// 获取能量值。
        /// </summary>
        public float Energy => drFighter.Energy;


        /// <summary>
        /// 获取最大能量值。
        /// </summary>
        public float MaxEnergy => drFighter.MaxEnergy;


        /// <summary>
        /// 获取分数奖励。
        /// </summary>
        public int ScoreBonus => drFighter.ScoreBonus;

    }
}