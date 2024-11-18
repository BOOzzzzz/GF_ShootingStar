using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class GameBase
    {
        public EnemyEntityLoader enemyEntityLoader;
        
        public virtual void Initialize()
        {
            enemyEntityLoader = EnemyEntityLoader.Create();
            SpawnPlayer();
            enemyEntityLoader.SpawnEnemies(5);
        }

        public virtual void OnEnter()
        {
            GameEntry.Event.Subscribe(EnemyDieEventArgs.EventId,EnemyDie);
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        public virtual void OnLeave()
        {
            GameEntry.Event.Unsubscribe(EnemyDieEventArgs.EventId,EnemyDie);
            ReferencePool.Release(enemyEntityLoader);
        }

        private void EnemyDie(object sender, GameEventArgs e)
        {
            EnemyDieEventArgs args = e as EnemyDieEventArgs;
            if (args == null)
            {
                return;
            }
            enemyEntityLoader.HideEntity(args.EntityLogic);
        }

        private void SpawnPlayer()
        {
            GameEntry.Entity.ShowEntity<PlayerFighterLogic>(FighterEntityData.Create(EnumEntity.PlayerFighter,
                EnumEntity.PlayerThruster, EnumEntity.PlayerWeapon, new Vector3(-7, 0, 0)));
        }
    }
}