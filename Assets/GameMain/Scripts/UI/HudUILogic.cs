using System.Collections;
using GameFramework.Event;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class HudUILogic : UIFormBaseLogic
    {
        [SerializeField] private Image healthFillImageBack;
        [SerializeField] private Image healthFillImageFront;
        [SerializeField] private Text healthText;
        [SerializeField] private Image energyFillImageBack;
        [SerializeField] private Image energyFillImageFront;
        [SerializeField] private Text energyText;
        [SerializeField] private Text scoreText;

        private GameSurvive currentGame;
        private FighterLogic fighterLogic;
        private Coroutine fillHealthCoroutine;
        private Coroutine fillEnergyCoroutine;
        private WaitForSeconds delayFillTime = new(1);
        private float timer;
        private float currentHealthValue;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            if (userData ==null)
            {
                Log.Debug("have not HUD userData");
            }
            currentGame = userData as GameSurvive;
            
            fighterLogic = GameObject.FindWithTag("Player").GetComponent<FighterLogic>();
            if (fighterLogic != null)
            {
                fighterLogic.updateHealthBar += UpdateHealthBar;
                fighterLogic.updateEnergyBar += UpdateEnergyBar;
            }

            GameEntry.Event.Fire(AddEnergyEventArgs.EventId, AddEnergyEventArgs.Create(100));
            GameEntry.Event.Subscribe(EnemyDieEventArgs.EventId, UpdateScore);
            UpdateEnergyBar(true);
        }

        private void UpdateScore(object sender, GameEventArgs e)
        {
            scoreText.text =  currentGame.score.ToString();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            fighterLogic.updateHealthBar -= UpdateHealthBar;
            fighterLogic.updateEnergyBar -= UpdateEnergyBar;
            
            GameEntry.Event.Unsubscribe(EnemyDieEventArgs.EventId, UpdateScore);
        }

        private void UpdateHealthBar(bool isRecover)
        {
            if (fillHealthCoroutine != null) StopCoroutine(fillHealthCoroutine);

            Image directFillImage = isRecover ? healthFillImageBack : healthFillImageFront;
            Image bufferFillImage = isRecover ? healthFillImageFront : healthFillImageBack;

            directFillImage.fillAmount =
                fighterLogic.fighterEntityData.Health / fighterLogic.fighterEntityData.MaxHealth;
            healthText.text = Mathf.RoundToInt(directFillImage.fillAmount * 100) + "%";

            fillHealthCoroutine = StartCoroutine(SmoothUpdateStateBar(directFillImage.fillAmount,
                bufferFillImage.fillAmount,
                bufferFillImage,  0.3f));
        }

        private void UpdateEnergyBar(bool isRecover)
        {
            if (fillEnergyCoroutine != null) StopCoroutine(fillEnergyCoroutine);

            Image directFillImage = isRecover ? energyFillImageBack : energyFillImageFront;
            Image bufferFillImage = isRecover ? energyFillImageFront : energyFillImageBack;

            directFillImage.fillAmount =
                fighterLogic.fighterEntityData.Energy / fighterLogic.fighterEntityData.MaxEnergy;
            energyText.text = Mathf.RoundToInt(directFillImage.fillAmount * 100) + "%";

            fillEnergyCoroutine = StartCoroutine(SmoothUpdateStateBar(directFillImage.fillAmount,
                bufferFillImage.fillAmount,
                bufferFillImage,  0.3f));
        }

        private IEnumerator SmoothUpdateStateBar(float targetFillAmount, float currentFillAmount, Image fillImage,
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