
using UnityEngine;

namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowPlayerFighter(new PlayerFighterData(10000)
            {
                Position = new Vector3(-7,1,0)
            });
        }

        public virtual void Update( float elapseSeconds, float realElapseSeconds)
        {
            
        }
    }
}