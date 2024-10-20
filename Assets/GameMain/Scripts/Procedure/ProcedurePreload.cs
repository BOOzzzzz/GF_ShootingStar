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

            GameEntry.Data.OnLoadAllDatas();
            
            GameEntry.Scene.LoadScene("Assets/GameMain/Scenes/Game.unity");
            ChangeState<ProcedureGame>(procedureOwner);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private void OnPreLoad()
        {
            GameEntry.Data.OnPreloadAllDatas();
            
        }
    }
}