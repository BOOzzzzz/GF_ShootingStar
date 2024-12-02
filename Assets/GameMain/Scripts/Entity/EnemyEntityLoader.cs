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
        private int uiFormID;

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

        public void SpawnEnemies(int count)
        {
            CoroutineRunner.Instance.StartCoroutineRunner(LoadEnemiesAndUI(false, 5));
        }

        public void SpawnBoss()
        {
            CoroutineRunner.Instance.StartCoroutineRunner(LoadEnemiesAndUI(true));
        }

        private IEnumerator LoadEnemiesAndUI(bool isBoss, int count = 1)
        {
            while (waveNum < 3)
            {
                waveNum++;
                uiFormID = GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("WaveUI"), "Default", userData: waveNum);
                yield return new WaitForSeconds(3);
                GameEntry.UI.CloseUIForm(uiFormID);

                if (isBoss)
                {
                    GameEntry.Entity.ShowEntity<BossFighterLogic>(FighterEntityData.Create(
                        EnumEntity.Boss, EnumEntity.BossThruster,
                        EnumEntity.BossWeapon, EnumEntity.BossHealthBar, EnumEntity.VFXEnemyMuzzleFire,
                        new Vector3(10,
                            Random.Range(EntityExtension.MinVerticalDistance, EntityExtension.MaxVerticalDistance),
                            0), thrusterPosition:
                        new Vector3(-0.1f, -0.6f, -5f),thrusterRotation:Quaternion.Euler(0,90,0),healthBarOffset:1f));
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        RandomSpawnEnemy();
                    }
                }

                //加载实体是异步的，等待一帧
                yield return null;

                yield return waitUntilNoEnemy;
            }
        }

        public void RandomSpawnEnemy()
        {
            GameEntry.Entity.ShowEntity<EnemyFighterLogic>(FighterEntityData.Create(
                EnumExtension.RandomRange(EnumEntity.Enemy01, EnumEntity.Enemy03), EnumEntity.EnemyThruster,
                EnumEntity.EnemyWeapon, EnumEntity.EnemyHealthBar, EnumEntity.VFXEnemyMuzzleFire,
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

            if (args.EntityLogicType == typeof(BossFighterLogic))
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