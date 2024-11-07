using System.Collections.Generic;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class GameBase:IReference
    {
        private EntityLoader entityLoader;

        public int playerID;
        public List<int> enemiesID;

        public virtual void Initialize()
        {
            entityLoader = EntityLoader.Create(this);
            SpawnPlayer();
            SpawnEnemy();
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
            
        }

        public void SpawnPlayer()
        {
            playerID = entityLoader.ShowEntity<PlayerFighterLogic>(FighterEntityData.Create(EnumEntity.PlayerFighter,
                EnumEntity.PlayerThruster, EnumEntity.PlayerWeapon, new Vector3(-7, 0, 0)));
        }

        public void SpawnEnemy()
        {
            GameEntry.Entity.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(EnumEntity.Enemy01,
                EnumEntity.EnemyThruster01, EnumEntity.EnemyWeapon01, new Vector3(7, 0, 0)));
            
            GameEntry.Entity.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(EnumEntity.Enemy02,
                EnumEntity.EnemyThruster02, EnumEntity.EnemyWeapon02, new Vector3(7, 2, 0)));
            
            GameEntry.Entity.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(EnumEntity.Enemy03,
                EnumEntity.EnemyThruster03, EnumEntity.EnemyWeapon03, new Vector3(7, -2, 0)));
        }

        public void Clear()
        {
            if (entityLoader != null)
                ReferencePool.Release(entityLoader);
            entityLoader = null;
        }
    }
}