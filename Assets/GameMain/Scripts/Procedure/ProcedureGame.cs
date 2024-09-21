using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class ProcedureGame : ProcedureBase
    {
        private Dictionary<GameMode,GameBase> games=new Dictionary<GameMode,GameBase>();
        private GameBase currentGame;

        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
            games.Add(GameMode.Survive,new GameSurvive());
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("ProcedureGame");
            currentGame = games[GameMode.Survive];
            currentGame.Initialize();
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            currentGame.Update(elapseSeconds, realElapseSeconds);
        }
    }
}