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
                EnumEntity.EnemyThruster01, EnumEntity.EnemyWeapon01, new Vector3(7, 0, 0)));
            
            GameEntry.Entity.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(EnumEntity.Enemy02,
                EnumEntity.EnemyThruster02, EnumEntity.EnemyWeapon02, new Vector3(7, 2, 0)));
            
            GameEntry.Entity.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(EnumEntity.Enemy03,
                EnumEntity.EnemyThruster03, EnumEntity.EnemyWeapon03, new Vector3(7, -2, 0)));
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }
    }
}