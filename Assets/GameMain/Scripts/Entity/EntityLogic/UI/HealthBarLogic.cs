using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class HealthBarLogic : EntityBaseLogic
    {
        private HealthBarEntityData healthBarEntityData;
        private Vector3 offset = new Vector3(0.15f, 0.6f, 0);

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            healthBarEntityData = userData as HealthBarEntityData;
            if (healthBarEntityData == null)
            {
                Log.Warning("HealthBarEntityData is not initialized");
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            transform.position = healthBarEntityData.Follow.position + offset;
        }
    }
}