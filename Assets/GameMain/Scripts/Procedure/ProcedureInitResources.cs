using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ShootingStar
{
    public class ProcedureInitResources:ProcedureBase
    {
        private bool initResourceComplete = false;

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("ProcedureInitResources");
            
            initResourceComplete = false;

            GameEntry.Resource.InitResources(OnInitResourceComplete);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (initResourceComplete)
                ChangeState<ProcedurePreload>(procedureOwner);
        }


        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }

        private void OnInitResourceComplete()
        {
            initResourceComplete = true;
            Log.Info("Init resources complete.");
        }
    }
}