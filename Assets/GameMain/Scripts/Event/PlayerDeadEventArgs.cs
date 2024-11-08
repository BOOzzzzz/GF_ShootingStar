using GameFramework;
using GameFramework.Event;

namespace GameMain.Scripts.Event
{
    public class PlayerDeadEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PlayerDeadEventArgs).GetHashCode();

        public override int Id => EventId;
        
        public static PlayerDeadEventArgs Create()
        {
            PlayerDeadEventArgs playerDeadEventArgs = ReferencePool.Acquire<PlayerDeadEventArgs>();
            return playerDeadEventArgs;
        }

        public override void Clear()
        {
        }
    }
}