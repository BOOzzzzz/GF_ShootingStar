using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using ShootingStar.Data;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

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

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
            
            PlayerInputManager.Instance.OnInit();
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("ProcedurePreload");

            List<GameFramework.Data.Data> datas = GameEntry.Data.GetAllDatas();
            for (int i = 0; i < datas.Count; i++)
            {
                baseDatas.Add(datas[i] as BaseDatas);
            }

            OnPreLoad();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds,
            float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            foreach (var baseData in baseDatas)
            {
                if(!baseData.IsPreLoaded)
                    return;
            }

            GameEntry.Data.OnLoadAllDatas();
            
            procedureOwner.SetData<VarString>("SceneName","Menu");
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private void OnPreLoad()
        {
            GameEntry.Data.OnPreloadAllDatas();
            
        }
    }
}