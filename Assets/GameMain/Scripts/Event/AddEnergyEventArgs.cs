using GameFramework;
using GameFramework.Event;
using ShootingStar;

namespace GameMain.Scripts.Event
{
    public class AddEnergyEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(AddEnergyEventArgs).GetHashCode();

        public override int Id => EventId;
        
        public int EnergyValue { get; set; }

        public static AddEnergyEventArgs Create(int value)
        {
            AddEnergyEventArgs addEnergyEventArgs = ReferencePool.Acquire<AddEnergyEventArgs>();
            addEnergyEventArgs.EnergyValue = value;
            return addEnergyEventArgs;
        }

        public override void Clear()
        {
        }
    }
}