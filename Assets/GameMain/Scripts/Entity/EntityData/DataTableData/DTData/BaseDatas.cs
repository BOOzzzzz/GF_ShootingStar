using System.Collections.Generic;

namespace ShootingStar.DataTableData
{
    public abstract class BaseDatas:GameFramework.Data.Data
    {
        public Dictionary<string,bool> loadedFlags = new Dictionary<string,bool>();
        
        public void LoadDataTable(string dataTableName)
        {
            string dataTableAssetName = AssetUtility.GetDataTableAsset(dataTableName, false);
            loadedFlags.Add(dataTableAssetName, false);
            GameEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
        }
    }
}