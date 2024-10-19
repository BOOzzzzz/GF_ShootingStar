using GameFramework;
using ShootingStar.ReferencePoolData;

namespace ShootingStar
{
    public class FighterEntityData : EntityBaseData
    {
        public EntityData entityData;
        public FighterData fighterData;

        public FighterEntityData Create(FighterData fighterData,EntityData entityData)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = entityData;
            fighterEntityData.fighterData = fighterData;
            return fighterEntityData;
        }
    }
}