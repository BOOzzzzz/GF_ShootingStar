
using System.Threading.Tasks;
using GameFramework.Event;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class GameSurvive : GameBase
    {
        public int score;
        
        public override void Initialize()
        {
            base.Initialize();
            Log.Debug("GameSurvive");
        }

        protected override void EnemyDie(object sender, GameEventArgs e)
        {
            base.EnemyDie(sender, e);
            
            if (e is EnemyDieEventArgs ne)
            {
                score += ((EnemyFighterLogic)ne.EntityLogic).fighterEntityData.ScoreBonus;
            }
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);
        }

        public override void OnLeave()
        {
            base.OnLeave();
        }
    }
}
