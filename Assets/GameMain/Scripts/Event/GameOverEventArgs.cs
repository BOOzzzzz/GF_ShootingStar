using GameFramework;
using GameFramework.Event;

namespace GameMain.Scripts.Event
{
    public class GameOverEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(GameOverEventArgs).GetHashCode();

        public override int Id => EventId;
        
        public static GameOverEventArgs Create()
        {
            GameOverEventArgs gameOverEventArgs = ReferencePool.Acquire<GameOverEventArgs>();
            return gameOverEventArgs;
        }

        public override void Clear()
        {
        }
    }
}