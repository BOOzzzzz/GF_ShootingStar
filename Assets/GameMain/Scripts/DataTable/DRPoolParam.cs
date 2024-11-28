//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-28 22:58:25.743
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
    /// 池参数表。
    /// </summary>
    public class DRPoolParam : DataRowBase
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
        /// 获取实例自动释放间隔。
        /// </summary>
        public float InstanceAutoReleaseInterval
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实例容量。
        /// </summary>
        public int InstanceCapacity
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实例过期时间。
        /// </summary>
        public float InstanceExpireTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实例优先级。
        /// </summary>
        public int InstancePriority
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
            InstanceAutoReleaseInterval = float.Parse(columnStrings[index++]);
            InstanceCapacity = int.Parse(columnStrings[index++]);
            InstanceExpireTime = float.Parse(columnStrings[index++]);
            InstancePriority = int.Parse(columnStrings[index++]);

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
                    InstanceAutoReleaseInterval = binaryReader.ReadSingle();
                    InstanceCapacity = binaryReader.Read7BitEncodedInt32();
                    InstanceExpireTime = binaryReader.ReadSingle();
                    InstancePriority = binaryReader.Read7BitEncodedInt32();
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
