using GameFramework;
using ShootingStar.DataTableData;
using ShootingStar.ReferencePoolData;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class FighterEntityData : EntityBaseData
    {
        public EntityData entityData;
        public FighterData fighterData;

        public static FighterEntityData Create(EnumEntity id)
        {
            FighterEntityData fighterEntityData = ReferencePool.Acquire<FighterEntityData>();
            fighterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            fighterEntityData.fighterData = GameEntry.Data.GetData<FighterDatas>().GetFighterData(id);
            return fighterEntityData;
        }
    }
}