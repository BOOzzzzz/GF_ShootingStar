using System.Collections;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class AutoDisableEntityLogic:EntityBaseLogic
    {
        
        private readonly WaitForSeconds disabledTime = new (4);

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            StartCoroutine(nameof(AutoDisabled));
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            
            StopAllCoroutines();
        }


        private IEnumerator AutoDisabled()
        {
            yield return disabledTime;
            GameEntry.Entity.HideEntity(this);
            Release();
        }

        protected abstract void Release();
    }
}