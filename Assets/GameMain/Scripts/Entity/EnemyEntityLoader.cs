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
    public class EnemyEntityLoader : IReference
    {
        public List<GameObject> enemyEntities;

        public EnemyEntityLoader()
        {
            enemyEntities = new List<GameObject>();
        }

        public static EnemyEntityLoader Create()
        {
            EnemyEntityLoader enemyEntityLoader = ReferencePool.Acquire<EnemyEntityLoader>();
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, enemyEntityLoader.OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, enemyEntityLoader.OnShowEntityFail);
            return enemyEntityLoader;
        }

        public void ShowEntity<T>(EntityBaseData data) where T : EntityBaseLogic
        {
            GameEntry.Entity.ShowEntity(typeof(T), AssetUtility.GetEntityAsset(data.entityData.AssetName),
                data.entityData.GroupName, data);
        }

        public void HideEntity<T>(T entity) where T : EntityBaseLogic
        {
            GameEntry.Entity.HideEntity(entity);
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

        private void OnShowEntityFail(object sender, GameEventArgs e)
        {
        }

        private void OnShowEntitySuccess(object sender, GameEventArgs e)
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

        public void Clear()
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFail);
            enemyEntities.Clear();
        }
    }
}