using System;
using System.IO;
using System.Text;
using GameFramework;
using ShootingStar;
using ShootingStar.Editor.DataTableTools;
using UnityEditor;
using UnityEngine;

namespace ShootingStar.Editor.DataTableTools
{
    public sealed partial class DataTableGeneratorMenu
    {

        [MenuItem("ShootingStar/Generate DataTable Data",false,2)]
        private static void OneClickDataTableGenerator()
        {
            GenerateDataTables();
            GenerateDataTableData();
            GenerateDataTableAllDatas();
        }

    }
}