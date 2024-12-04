#if UNITY_EDITOR
using UnityEditor;

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
#endif