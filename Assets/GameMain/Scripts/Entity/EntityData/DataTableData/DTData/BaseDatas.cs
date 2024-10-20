using System.Collections.Generic;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace ShootingStar.DataTableData
{
    public abstract class BaseDatas:GameFramework.Data.Data
    {
        public Dictionary<string,bool> loadedFlags = new Dictionary<string,bool>();

        public override void Preload()
        {
            GameEntry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, LoadDataTableSuccess);
            GameEntry.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, LoadDataTableFailure);
            
            OnPreload();
        }

        public override void Load()
        {
            GameEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, LoadDataTableSuccess);
            GameEntry.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, LoadDataTableFailure);
            
            OnLoad();
        }

        public virtual void OnPreload()
        {
            
        }

        public virtual void OnLoad()
        {
            
        }
        
        public void LoadDataTable(string dataTableName)
        {
            string dataTableAssetName = AssetUtility.GetDataTableAsset(dataTableName, false);
            loadedFlags.Add(dataTableAssetName, false);
            GameEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
        }
        
        

        private void LoadDataTableSuccess(object sender, GameEventArgs e)
        {
            LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            loadedFlags[ne.DataTableAssetName] = true;
            Log.Info("Load data table '{0}' OK.", ne.DataTableAssetName);
        }

        private void LoadDataTableFailure(object sender, GameEventArgs e)
        {
            LoadDataTableFailureEventArgs ne = (LoadDataTableFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", ne.DataTableAssetName,
                ne.DataTableAssetName, ne.ErrorMessage);
        }
    }
}