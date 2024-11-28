// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-28 22:58:25.884
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
    public class PoolParamData 
    {
        private DRPoolParam drPoolParam;
        
        public PoolParamData(DRPoolParam drPoolParam)
        {
            this.drPoolParam = drPoolParam;
        }
        
        public int ID
        {
             get => drPoolParam.Id;
        }
        
        /// <summary>
        /// 获取实例自动释放间隔。
        /// </summary>
        public float InstanceAutoReleaseInterval => drPoolParam.InstanceAutoReleaseInterval;


        /// <summary>
        /// 获取实例容量。
        /// </summary>
        public int InstanceCapacity => drPoolParam.InstanceCapacity;


        /// <summary>
        /// 获取实例过期时间。
        /// </summary>
        public float InstanceExpireTime => drPoolParam.InstanceExpireTime;


        /// <summary>
        /// 获取实例优先级。
        /// </summary>
        public int InstancePriority => drPoolParam.InstancePriority;

    }
}