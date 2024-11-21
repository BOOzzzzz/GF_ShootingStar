using System;
using System.Collections;
using GameFramework.Event;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class HealthBarLogic : EntityBaseLogic
    {
        private HealthBarEntityData healthBarEntityData;
        private readonly Vector3 offset = new Vector3(0.15f, 0.6f, 0);
        private Image fillImageFront;
        private Image fillImageBack;
        private FighterLogic fighterLogic;
        private Coroutine fillCoroutine;
        private WaitForSeconds delayFillTime;
        private float timer;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            healthBarEntityData = userData as HealthBarEntityData;
            if (healthBarEntityData == null)
            {
                Log.Warning("HealthBarEntityData is not initialized");
            }

            fillImageBack = transform.GetChild(1).GetComponent<Image>();
            fillImageFront = transform.GetChild(2).GetComponent<Image>();
            fighterLogic = healthBarEntityData?.Follow.GetComponent<FighterLogic>();
            delayFillTime = new WaitForSeconds(1);
            if (fighterLogic != null) fighterLogic.updateHealthBar += UpdateHealthBar;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            transform.position = healthBarEntityData.Follow.position + offset;

            if (!healthBarEntityData.Follow.gameObject.activeSelf)
            {
                GameEntry.Entity.HideEntity(this);
            }
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