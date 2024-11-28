using GameFramework;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class MuzzleVFXLogic:EntityBaseLogic
    {
        public ParticleSystem muzzleParticleSystem;

        private VFXAccessoryEntityData vfxAccessoryEntityData;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            muzzleParticleSystem = GetComponent<ParticleSystem>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            vfxAccessoryEntityData = userData as VFXAccessoryEntityData;
            if (vfxAccessoryEntityData == null)
            {
                Log.Warning("vfxAccessoryEntityData is not initialized");
                return;
            }

            GameEntry.Entity.AttachEntity(Entity, vfxAccessoryEntityData.OwnerId, "Muzzle");
            InitData(vfxAccessoryEntityData);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            ReferencePool.Release(vfxAccessoryEntityData);
        }

    }
}