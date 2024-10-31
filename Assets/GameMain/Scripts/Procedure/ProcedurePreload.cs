using System.Collections.Generic;
using GameFramework.Data;
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
        private List<BaseDatas> baseDatas = new List<BaseDatas>();
        
        public static string[] DataTableNames = new string[]
        {
            "Entity",
            "Thruster",
            "Fighter",
            "Weapon",
            "Bullet",
        };

        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
            
            PlayerInputManager.Instance.OnInit();
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            List<Data> datas = GameEntry.Data.GetAllDatas();
            for (int i = 0; i < datas.Count; i++)
            {
                baseDatas.Add(datas[i] as BaseDatas);
            }

            OnPreLoad();
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds,
            float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            foreach (var baseData in baseDatas)
            {
                if(!baseData.IsPreLoaded)
                    return;
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