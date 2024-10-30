using UnityEngine;

namespace ShootingStar
{
    public abstract class GameBase
    {
        public virtual void Initialize()
        {
            GameEntry.Entity.ShowEntity<PlayerFighterLogic>(FighterEntityData.Create(EnumEntity.PlayerFighter,
                EnumEntity.PlayerThruster, EnumEntity.PlayerWeapon, new Vector3(-7, 0, 0)));
            
            GameEntry.Entity.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(EnumEntity.Enemy01,
                EnumEntity.EnemyThruster, EnumEntity.EnemyWeapon, new Vector3(7, 0, 0)));
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }
    }
}