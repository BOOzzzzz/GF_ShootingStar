using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : EntityLogic
    {
        private PlayerFighterData playerFighterData;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            playerFighterData = userData as PlayerFighterData;
            if (playerFighterData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }

            InitData();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        }

        private void InitData()
        {
            CachedTransform.position = playerFighterData.Position;
            CachedTransform.rotation = playerFighterData.Rotation;
        }
    }
}