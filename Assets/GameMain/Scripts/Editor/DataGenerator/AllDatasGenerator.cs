using System;
using System.IO;
using System.Text;
using GameFramework;
using ShootingStar;
using ShootingStar.Editor.DataTableTools;
using UnityEditor;
using UnityEngine;

namespace GameMain.Scripts.Editor
{
    public class AllDatasGenerator
    {
        private readonly static string DataTemplateFileName = "Assets/GameMain/Configs/AllDatasTemplate.txt";
        private readonly static string GeneratePath = "Assets/GameMain/Scripts/Data/DTData";

        [MenuItem("ShootingStar/Generate DataTable Data/Generate AllDatas(需要先进行Generate Data)",false,4)]
        private static void GenerateDataTableData()
        {
            foreach (string dataTableName in ProcedurePreload.DataTableNames)
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
                Utility.Path.GetRegularPath(Path.Combine(GeneratePath, dataTableName + "Datas" + ".cs"));
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
            codeContent.Replace("__DATAS_TABLE__", dataTableName);
            codeContent.Replace("__DATAS_TABLE_b__", dataTableName.ToLower());
            //codeContent.Replace("__DATA_TABLE_DATA_ITEM__", GenerateDataItems(dataTableProcessor, dataTableName));
        }

        private static string GenerateDataItems(DataTableProcessor dataTableProcessor, string dataTableName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool firstProperty = true;
            for (int i = 0; i < dataTableProcessor.RawColumnCount; i++)
            {
                if (dataTableProcessor.IsCommentColumn(i))
                {
                    // 注释列
                    continue;
                }

                if (dataTableProcessor.IsIdColumn(i))
                {
                    // 编号列
                    continue;
                }

                if (firstProperty)
                {
                    firstProperty = false;
                }
                else
                {
                    stringBuilder.AppendLine().AppendLine();
                }

                stringBuilder
                    .AppendLine("        /// <summary>")
                    .AppendFormat("        /// 获取{0}。", dataTableProcessor.GetComment(i)).AppendLine()
                    .AppendLine("        /// </summary>")
                    .AppendFormat("        public {0} {1} => dr{2}.{3};", dataTableProcessor.GetLanguageKeyword(i),
                        dataTableProcessor.GetName(i), dataTableName, dataTableProcessor.GetName(i)).AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}