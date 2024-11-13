using System;
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
        private Image fillImage;
        private FighterLogic fighterLogic;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            healthBarEntityData = userData as HealthBarEntityData;
            if (healthBarEntityData == null)
            {
                Log.Warning("HealthBarEntityData is not initialized");
            }

            fillImage = transform.GetChild(2).GetComponent<Image>();
            fighterLogic = healthBarEntityData?.Follow.GetComponent<FighterLogic>();
            if (fighterLogic != null) fighterLogic.updateHealthBar = UpdateHealthBar;
            UpdateHealthBar();
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

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

        private void UpdateHealthBar()
        {
            fillImage.fillAmount = fighterLogic.fighterEntityData.Health / fighterLogic.fighterEntityData.MaxHealth;
        }
    }
}