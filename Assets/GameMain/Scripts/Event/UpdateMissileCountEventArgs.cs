using GameFramework;
using GameFramework.Event;
using ShootingStar;

namespace GameMain.Scripts.Event
{
    public class UpdateMissileCountEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UpdateMissileCountEventArgs).GetHashCode();

        public override int Id => EventId;

        public static UpdateMissileCountEventArgs Create()
        {
            UpdateMissileCountEventArgs updateMissileCountEventArgs = ReferencePool.Acquire<UpdateMissileCountEventArgs>();
            return updateMissileCountEventArgs;
        }

        public override void Clear()
        {
        }
    }
}