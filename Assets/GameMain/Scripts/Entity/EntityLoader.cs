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