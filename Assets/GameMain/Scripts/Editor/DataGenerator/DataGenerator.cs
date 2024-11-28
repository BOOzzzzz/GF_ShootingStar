using System;
using UnityEditor;
using System.IO;
using System.Text;
using GameFramework;
using ShootingStar;
using ShootingStar.Editor.DataTableTools;
using UnityEngine;

namespace ShootingStar.Editor.DataTableTools
{
    public sealed partial class DataTableGeneratorMenu
    {
        private readonly static string DataTemplateFileName = "Assets/GameMain/Configs/DataTemplate.txt";
        private readonly static string DataGeneratePath = "Assets/GameMain/Scripts/Data/DRData";

        private static void GenerateDataTableData()
        {
            foreach (string dataTableName in DataTableNameScanner.GetDataTableNames())
            {
                DataTableProcessor dataTableProcessor = DataTableGenerator.CreateDataTableProcessor(dataTableName);
                if (!DataTableGenerator.CheckRawData(dataTableProcessor, dataTableName))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                    break;
                }

                GenerateDataFile(dataTableProcessor, dataTableName);
            }

            AssetDatabase.Refresh();
        }

        public static void GenerateDataFile(DataTableProcessor dataTableProcessor, string dataTableName)
        {
            dataTableProcessor.SetCodeTemplate(DataTemplateFileName, Encoding.UTF8);
            dataTableProcessor.SetCodeGenerator(DataTableCodeGenerator);

            string csharpCodeFileName =
                Utility.Path.GetRegularPath(Path.Combine(DataGeneratePath, dataTableName + "Data" + ".cs"));
            if (!dataTableProcessor.GenerateCodeFile(csharpCodeFileName, Encoding.UTF8, dataTableName) &&
                File.Exists(csharpCodeFileName))
            {
                File.Delete(csharpCodeFileName);
            }
        }

        private static void DataTableCodeGenerator(DataTableProcessor dataTableProcessor, StringBuilder codeContent,
            object userData)
        {
            string dataTableName = (string)userData;

            codeContent.Replace("__DATA_TABLE_CREATE_TIME__", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            codeContent.Replace("__DATA_TABLE_NAME_SPACE__", "ShootingStar.Data");
            codeContent.Replace("__DATA_TABLE__", dataTableName);
            codeContent.Replace("__DATA_TABLE_DATA_ITEM__", GenerateDataItems(dataTableProcessor, dataTableName));
        }
    }
}