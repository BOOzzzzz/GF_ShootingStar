﻿// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-28 22:58:25.880
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
    public class EntityData 
    {
        private DREntity drEntity;
        
        public EntityData(DREntity drEntity)
        {
            this.drEntity = drEntity;
        }
        
        public int ID
        {
             get => drEntity.Id;
        }
        
        /// <summary>
        /// 获取资源名称。
        /// </summary>
        public string AssetName => drEntity.AssetName;


        /// <summary>
        /// 获取资源组名称。
        /// </summary>
        public string GroupName => drEntity.GroupName;


        /// <summary>
        /// 获取池参数编号。
        /// </summary>
        public int PoolParamID => drEntity.PoolParamID;

    }
}