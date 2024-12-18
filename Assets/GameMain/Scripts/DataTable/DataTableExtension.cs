﻿using System;
using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public static class DataTableExtension
    {
        internal static readonly char[] DataSplitSeparators = new char[] { '\t' };
        internal static readonly char[] DataTrimSeparators = new char[] { '\"' };
        private const string classTypePrefixName = "ShootingStar.DR";

        public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName,
            string dataTableAssetName,object userData)
        {
            string classTypeName = classTypePrefixName + dataTableName;
            Type classType = Type.GetType(classTypeName);
            DataTableBase dataTableBase =  dataTableComponent.CreateDataTable(classType);
            dataTableBase.ReadData(dataTableAssetName,userData);
        }
        
        public static Vector2 ParseVector2(string value)
        {
            string[] splitedValue = value.Split(',');
            return new Vector2(float.Parse(splitedValue[0]), float.Parse(splitedValue[1]));
        }
    }
}