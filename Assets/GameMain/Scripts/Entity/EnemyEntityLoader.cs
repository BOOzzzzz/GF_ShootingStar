using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;

namespace ShootingStar
{
    public class EnemyEntityLoader : EntityLoader
    {
        public List<GameObject> enemyEntities = new();

        public override void HideEntity<T>(T entity)
        {
            base.HideEntity(entity);
            enemyEntities.Remove(entity.Entity.gameObject);
        }

        public GameObject EnemyTarget()
        {
            if (enemyEntities.Count > 0)
            {
                return enemyEntities[Random.Range(0, enemyEntities.Count)];
            }
            else
            {
                return null;
            }
        }

        public void SpawnEnemies(int count)
        {
            for (int i = 0; i < count; i++)
            {
                RandomSpawnEnemy();
            }
        }

        public void RandomSpawnEnemy()
        {
            ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(
                EnumExtension.RandomRange(EnumEntity.Enemy01, EnumEntity.Enemy03), EnumEntity.EnemyThruster, EnumEntity.EnemyWeapon,
                new Vector3(10, Random.Range(EntityExtension.MinVerticalDistance, EntityExtension.MaxVerticalDistance), 0)));
        }

        protected override void OnShowEntityFail(object sender, GameEventArgs e)
        {
        }

        protected override void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs args = e as ShowEntitySuccessEventArgs;
            if (args == null)
            {
                return;
            }

            if (args.EntityLogicType == typeof(EnemyFighterLogic))
            {
                enemyEntities.Add(args.Entity.gameObject);
            }
        }

        public override void Clear()
        {
            base.Clear();
            enemyEntities.Clear();
        }
    }
}