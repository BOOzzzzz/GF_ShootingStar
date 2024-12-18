using System.Collections;
using GameFramework;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class HealthBarLogic : EntityBaseLogic
    {
        private HealthBarEntityData healthBarEntityData;
        private Vector3 offset;
        private Image fillImageFront;
        private Image fillImageBack;
        private FighterLogic fighterLogic;
        private Coroutine fillCoroutine;
        private WaitForSeconds delayFillTime;
        private float timer;
        private Canvas canvas;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            canvas = GetComponent<Canvas>();
            canvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
        

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            healthBarEntityData = userData as HealthBarEntityData;
            if (healthBarEntityData == null)
            {
                Log.Warning("HealthBarEntityData is not initialized");
                return;
            }

            offset = new Vector3(0.15f, healthBarEntityData.Offset, 0);
            fillImageBack = transform.GetChild(1).GetComponent<Image>();
            fillImageFront = transform.GetChild(2).GetComponent<Image>();
            fighterLogic = GameEntry.Entity.GetEntity(healthBarEntityData.FollowID).GetComponent<FighterLogic>();
            delayFillTime = new WaitForSeconds(1);
            if (fighterLogic == null)
                return;
            
            fighterLogic.updateHealthBar += UpdateHealthBar;
            fighterLogic.updateHealthBar.Invoke(true);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            transform.position = fighterLogic.transform.position + offset;

            if (!fighterLogic.transform.gameObject.activeSelf)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            
            fighterLogic.updateHealthBar -= UpdateHealthBar;
            ReferencePool.Release(healthBarEntityData);
        }

        private void UpdateHealthBar(bool isRecover)
        {
            if (fillCoroutine != null) StopCoroutine(fillCoroutine);

            Image directFillImage = isRecover ? fillImageBack : fillImageFront;
            Image bufferFillImage = isRecover ? fillImageFront : fillImageBack;

            directFillImage.fillAmount =
                fighterLogic.fighterEntityData.Health / fighterLogic.fighterEntityData.MaxHealth;
            
            fillCoroutine = StartCoroutine(SmoothUpdateHealthBar(directFillImage.fillAmount, bufferFillImage.fillAmount,
                bufferFillImage, 0.3f));
        }

        private IEnumerator SmoothUpdateHealthBar(float targetFillAmount, float currentFillAmount, Image fillImage,
            float duration)
        {
            yield return delayFillTime;

            timer = 0;

            while (timer <= duration)
            {
                timer += Time.deltaTime;
                fillImage.fillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, timer / duration);
                yield return null;
            }

            fillImage.fillAmount = targetFillAmount;
        }
    }
}