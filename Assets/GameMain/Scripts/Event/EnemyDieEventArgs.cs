using GameFramework;
using GameFramework.Event;
using ShootingStar;

namespace GameMain.Scripts.Event
{
    public class EnemyDieEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EnemyDieEventArgs).GetHashCode();

        public override int Id => EventId;

        public EntityBaseLogic EntityLogic { get; set; }

        public static EnemyDieEventArgs Create(EntityBaseLogic entityLogic)
        {
            EnemyDieEventArgs enemyDieEventArgs = ReferencePool.Acquire<EnemyDieEventArgs>();
            enemyDieEventArgs.EntityLogic = entityLogic;
            return enemyDieEventArgs;
        }

        public override void Clear()
        {
        }
    }
}