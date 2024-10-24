using ShootingStar.DataTableData;
using UnityEngine;

namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowPlayerFighter(FighterEntityData.Create(EnumEntity.PlayerFighter));
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }
    }
}