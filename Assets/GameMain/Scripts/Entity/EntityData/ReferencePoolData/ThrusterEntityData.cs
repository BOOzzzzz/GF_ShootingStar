using System;
using GameFramework;
using ShootingStar.ReferencePoolData;

namespace ShootingStar
{
    [Serializable]
    public class ThrusterEntityData:EntityBaseData
    {
        public EntityData entityData;
        public ThrusterData thrusterData;

        public ThrusterEntityData Create(ThrusterData thrusterData,EntityData entityData)
        {
            ThrusterEntityData thrusterEntityData = ReferencePool.Acquire<ThrusterEntityData>();
            thrusterEntityData.entityData = entityData;
            thrusterEntityData.thrusterData = thrusterData;
            return thrusterEntityData;
        }
    }
}