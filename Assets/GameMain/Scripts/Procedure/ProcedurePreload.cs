using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using ShootingStar.DataTableData;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class ProcedurePreload : ProcedureBase
    {
        public static string[] DataTableNames = new string[]
        {
            "Entity",
            "Thruster",
            "Fighter",
            "Weapon"
        };

        private Dictionary<string, bool> loadedFlags = new Dictionary<string, bool>();

        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
            
            PlayerInputManager.Instance.OnInit();
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, LoadDataTableSuccess);
            GameEntry.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, LoadDataTableFailure);

            loadedFlags.Clear();

            OnPreLoad();
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds,
            float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            foreach (var loadedFlagValue in loadedFlags.Values)
            {
                if (!loadedFlagValue)
                {
                    return;
                }
            }

            GameEntry.Scene.LoadScene("Assets/GameMain/Scenes/Game.unity");
            ChangeState<ProcedureGame>(procedureOwner);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, LoadDataTableSuccess);
            GameEntry.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, LoadDataTableFailure);
        }

        private void OnPreLoad()
        {
            GameEntry.Data.OnPreloadAllDatas();
        }

        private void LoadDataTable()
        {
            foreach (var dataTableName in DataTableNames)
            {
                string dataTableAssetName = AssetUtility.GetDataTableAsset(dataTableName, false);
                loadedFlags.Add(dataTableAssetName, false);
                GameEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
            }
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