using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class ThrusterLogic:EntityBaseLogic
    {
        private ThrusterData thrusterData;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            thrusterData = userData as ThrusterData;
            if (thrusterData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }
            GameEntry.Entity.AttachEntity(Entity,thrusterData.OwnerId,"Thruster");
            InitData(thrusterData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        }
    }
}