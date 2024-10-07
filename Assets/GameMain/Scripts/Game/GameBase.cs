
using UnityEngine;

namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowPlayerFighter(new PlayerFighterData(GameEntry.Entity.GenerateSerialId(),EnumEntity.PlayerFighter)
            {
                Position = new Vector3(-7,1,0)
            });
        }

        public virtual void Update( float elapseSeconds, float realElapseSeconds)
        {
            
        }
    }
}