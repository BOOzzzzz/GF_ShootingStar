using System.Collections;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class BulletLogic : EntityBaseLogic
    {
        [SerializeField]
        protected BulletEntityData bulletData;

        private readonly WaitForSeconds disabledTime = new (4);

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        
            bulletData = userData as BulletEntityData;
            if (bulletData == null)
            {
                Log.Warning("BulletData is not initialized");
            }
        
            InitData(bulletData);

            StartCoroutine(nameof(AutoDisabled));
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            
            Move();
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            
            StopAllCoroutines();
        }

        protected abstract void Move();

        private IEnumerator AutoDisabled()
        {
            yield return disabledTime;
            GameEntry.Entity.HideEntity(this);
            ReferencePool.Release(bulletData);
        }
    }
}