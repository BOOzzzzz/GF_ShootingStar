
namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowEntity<PlayerLogic>(1, "Assets/GameMain/Entities/PlayerFighter.prefab", "PlayerFighter", 1,
                null);
        }

        public virtual void Update( float elapseSeconds, float realElapseSeconds)
        {
            
        }
    }
}