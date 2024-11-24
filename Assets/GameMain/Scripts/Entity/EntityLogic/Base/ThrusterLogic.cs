using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    [Serializable]
    public class ThrusterLogic : EntityBaseLogic
    {
        [SerializeField] private ThrusterEntityData thrusterEntityData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            thrusterEntityData = userData as ThrusterEntityData;
            if (thrusterEntityData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }
            
            GameEntry.Entity.AttachEntity(Entity, thrusterEntityData.OwnerId, "Thruster");
            InitData(thrusterEntityData);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            ReferencePool.Release(thrusterEntityData);
        }
    }
}