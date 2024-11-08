using System.Collections.Generic;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class GameBase : IReference
    {
        private EntityLoader entityLoader;

        public int playerID = 0;
        public List<int> enemiesID = new List<int>();

        public virtual void Initialize()
        {
            entityLoader = EntityLoader.Create(this);
            SpawnPlayer();
            SpawnEnemies(5);
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        public void SpawnPlayer()
        {
            playerID = entityLoader.ShowEntity<PlayerFighterLogic>(FighterEntityData.Create(EnumEntity.PlayerFighter,
                EnumEntity.PlayerThruster, EnumEntity.PlayerWeapon, new Vector3(-7, 0, 0)));
        }

        public void SpawnEnemies(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int enemyID = RandomSpawmEnemy();
                enemiesID.Add(enemyID);
            }
        }

        public int RandomSpawmEnemy()
        {
            return entityLoader.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(
                EnumExtension.RandomRange(EnumEntity.Enemy01, EnumEntity.Enemy03),
                EnumExtension.RandomRange(EnumEntity.EnemyThruster01, EnumEntity.EnemyThruster03),
                EnumExtension.RandomRange(EnumEntity.EnemyWeapon01, EnumEntity.EnemyWeapon03),
                new Vector3(10, Random.Range(EntityExtension.MinVerticalDistance, EntityExtension.MaxVerticalDistance),
                    0)));
        }

        public void Clear()
        {
            if (entityLoader != null)
                ReferencePool.Release(entityLoader);
            entityLoader = null;
        }
    }
}