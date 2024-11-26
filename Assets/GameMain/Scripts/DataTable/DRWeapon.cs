//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-26 14:06:23.112
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
    /// 武器表。
    /// </summary>
    public class DRWeapon : DataRowBase
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
        /// 获取子弹威力。
        /// </summary>
        public int WeaponPower
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取武器攻击时间间隔。
        /// </summary>
        public float AttackInterval
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取是否过载。
        /// </summary>
        public bool IsOverDrive
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取导弹数量。
        /// </summary>
        public int MissileCount
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
            WeaponPower = int.Parse(columnStrings[index++]);
            AttackInterval = float.Parse(columnStrings[index++]);
            IsOverDrive = bool.Parse(columnStrings[index++]);
            MissileCount = int.Parse(columnStrings[index++]);

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
                    WeaponPower = binaryReader.Read7BitEncodedInt32();
                    AttackInterval = binaryReader.ReadSingle();
                    IsOverDrive = binaryReader.ReadBoolean();
                    MissileCount = binaryReader.Read7BitEncodedInt32();
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
