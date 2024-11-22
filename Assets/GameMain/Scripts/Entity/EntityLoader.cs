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
        public object Owner { get; private set; } = null;

        public static T Create<T>(object owner) where T : EntityLoader, new()
        {
            T entityLoader = ReferencePool.Acquire<T>();
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
        
        public virtual void HideEntity<T>(T entity) where T : EntityBaseLogic
        {
            GameEntry.Entity.HideEntity(entity);
        }

        protected virtual void OnShowEntityFail(object sender, GameEventArgs e)
        {
        }

        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs args = e as ShowEntitySuccessEventArgs;
            if (args == null)
            {
                return;
            }
        }

        public virtual void Clear()
        {
            Owner = null;
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFail);
        }
    }
}