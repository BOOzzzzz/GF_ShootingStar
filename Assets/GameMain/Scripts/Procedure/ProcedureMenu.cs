using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ShootingStar
{
    public class ProcedureMenu:ProcedureBase
    {
        public bool startGame = false;
        
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("ProcedureMenu");

            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("MainMenu"), "Default",this);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds,
            float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (startGame)
            {
                procedureOwner.SetData<VarString>("SceneName","Game");
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }
    }
}