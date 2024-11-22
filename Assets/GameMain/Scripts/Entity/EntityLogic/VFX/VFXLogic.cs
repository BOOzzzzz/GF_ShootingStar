using GameFramework;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class VFXLogic : AutoDisableEntityLogic
    {
        private VFXEntityData vfxEntityData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            vfxEntityData = userData as VFXEntityData;
            if (vfxEntityData == null)
            {
                Log.Warning("BulletData is not initialized");
            }

            InitData(vfxEntityData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (vfxEntityData.OwnerEntity == null)
            {
                return;
            }
            CachedTransform.position = vfxEntityData.OwnerEntity.transform.position;
        }

        protected override void Release()
        {
            ReferencePool.Release(vfxEntityData);
        }
    }
}