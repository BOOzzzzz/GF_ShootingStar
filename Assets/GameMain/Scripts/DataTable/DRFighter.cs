//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-19 14:31:25.774
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
    /// <summary>
    /// 战机表。
    /// </summary>
    public class DRFighter : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取属性编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取生命值。
        /// </summary>
        public float Health
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大生命值。
        /// </summary>
        public float MaxHealth
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取能量值。
        /// </summary>
        public float Energy
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大能量值。
        /// </summary>
        public float MaxEnergy
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            Health = float.Parse(columnStrings[index++]);
            MaxHealth = float.Parse(columnStrings[index++]);
            Energy = float.Parse(columnStrings[index++]);
            MaxEnergy = float.Parse(columnStrings[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    Health = binaryReader.ReadSingle();
                    MaxHealth = binaryReader.ReadSingle();
                    Energy = binaryReader.ReadSingle();
                    MaxEnergy = binaryReader.ReadSingle();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
