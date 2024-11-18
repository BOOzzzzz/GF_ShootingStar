using System.Collections.Generic;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ShootingStar
{
    public class ProcedureGame : ProcedureBase
    {
        private Dictionary<GameMode,GameBase> games=new Dictionary<GameMode,GameBase>();
        
        public GameBase currentGame;

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
            games.Add(GameMode.Survive,new GameSurvive());
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("ProcedureGame");
            currentGame = games[GameMode.Survive];
            currentGame.Initialize();
            currentGame.OnEnter();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            currentGame.Update(elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            currentGame.OnLeave();
        }
    }
}