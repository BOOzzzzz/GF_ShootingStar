using GameFramework.DataTable;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
            DataTableBase dataTableBase =  GameEntry.DataTable.CreateDataTable(typeof(DREntity));
            dataTableBase.ReadData("Assets/GameMain/DataTables/Entity.txt");
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("ProcedureLaunch");
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds,
            float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            GameEntry.Scene.LoadScene("Assets/GameMain/Scenes/Game.unity");
            ChangeState<ProcedureGame>(procedureOwner);
        }
    }
}
