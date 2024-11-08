using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EntityLoader : IReference
    {
        public GameObject playerEntity;
        public List<GameObject> enemyEntities;
        public object Owner { get; private set; }

        public EntityLoader()
        {
            playerEntity = null;
            enemyEntities = new List<GameObject>();
            Owner = null;
        }

        public static EntityLoader Create(object owner)
        {
            EntityLoader entityLoader = ReferencePool.Acquire<EntityLoader>();
            entityLoader.Owner = owner;
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, entityLoader.OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, entityLoader.OnShowEntityFail);

            return entityLoader;
        }

        public int ShowEntity<T>(EntityBaseData data) where T : EntityBaseLogic
        {
            GameEntry.Entity.ShowEntity(typeof(T), AssetUtility.GetEntityAsset(data.entityData.AssetName),
                data.entityData.GroupName, data);
            return data.Id;
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

            if (args.EntityLogicType == typeof(PlayerFighterLogic))
            {
                playerEntity = args.Entity.gameObject;
            }

            if (args.EntityLogicType == typeof(EnemyFighterLogic))
            {
                enemyEntities.Add(args.Entity.gameObject);
            }
        }

        public void Clear()
        {
            Owner = null;
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFail);
        }
    }
}