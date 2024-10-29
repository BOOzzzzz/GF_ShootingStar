
using UnityEngine;

namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowPlayerFighter(FighterEntityData.Create(EnumEntity.PlayerFighter,new Vector3(-7,0,0)));
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }
    }
}