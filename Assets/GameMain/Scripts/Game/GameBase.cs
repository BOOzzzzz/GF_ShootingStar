using ShootingStar.DataTableData;
using UnityEngine;

namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowPlayerFighter(FighterEntityData.Create(GameEntry.Data.GetData<FighterDatas>().GetFighterData(EnumEntity.PlayerFighter),
                (GameEntry.Data.GetData<EntityDatas>().GetEntityData(EnumEntity.PlayerFighter))));
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }
    }
}