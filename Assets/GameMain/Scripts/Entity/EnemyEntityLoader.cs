using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;

namespace ShootingStar
{
    public class EnemyEntityLoader : EntityLoader
    {
        
        public List<GameObject> enemyEntities = new();
        public int waveNum = 0;
        
        private WaitUntil waitUntilNoEnemy;

        public EnemyEntityLoader()
        {
            waitUntilNoEnemy = new WaitUntil(() => enemyEntities.Count == 0);
        }

        public void RemoveEntity<T>(T entity) where T : EntityBaseLogic
        {
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
        
        public IEnumerator SpawnEnemies(int count)
        {
            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("WaveUI"), "Default");
            yield return new WaitForSeconds(3);
            
            for (int i = 0; i < count; i++)
            {
                RandomSpawnEnemy();
            }

            waveNum++;
            yield return waitUntilNoEnemy;
        }

        public void RandomSpawnEnemy()
        {
            ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(
                EnumExtension.RandomRange(EnumEntity.Enemy01, EnumEntity.Enemy03), EnumEntity.EnemyThruster,
                EnumEntity.EnemyWeapon,
                new Vector3(10, Random.Range(EntityExtension.MinVerticalDistance, EntityExtension.MaxVerticalDistance),
                    0)));
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