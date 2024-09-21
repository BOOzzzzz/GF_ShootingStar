
namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowPlayerFighter(new PlayerFighterData(1,1,1));
        }

        public virtual void Update( float elapseSeconds, float realElapseSeconds)
        {
            
        }
    }
}