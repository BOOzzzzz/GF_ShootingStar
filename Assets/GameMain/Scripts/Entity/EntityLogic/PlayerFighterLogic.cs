using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : EntityBaseLogic
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

            InitData(playerFighterData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            GameEntry.Entity.ShowThruster(new ThrusterData(10001, playerFighterData.ID)
            {
                Position = new Vector3(-0.87f, -0.05f, 0)
            });

            GameEntry.Entity.ShowThruster(new ThrusterData(10002, playerFighterData.ID)
            {
                Position = new Vector3(-0.75f, -0.154f, 0.242f)
            });

            GameEntry.Entity.ShowThruster(new ThrusterData(10003, playerFighterData.ID)
            {
                Position = new Vector3(-0.75f, -0.154f, -0.242f)
            });
        }
    }
}