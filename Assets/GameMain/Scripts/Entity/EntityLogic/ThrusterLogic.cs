

using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class ThrusterLogic:EntityBaseLogic
    {
         private ThrusterEntityData thrusterEntityData;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            thrusterEntityData = userData as ThrusterEntityData;
            if (thrusterEntityData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }
            GameEntry.Entity.AttachEntity(Entity,thrusterEntityData.OwnerId,"Thruster");
            //InitData(thrusterData,true);
        }
        //
        // protected override void OnShow(object userData)
        // {
        //     base.OnShow(userData);
        // }
    }
}