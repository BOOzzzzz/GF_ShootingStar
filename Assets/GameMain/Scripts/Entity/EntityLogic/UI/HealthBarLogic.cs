using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class HealthBarLogic:EntityBaseLogic
    {
        private HealthBarEntityData healthBarEntityData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            healthBarEntityData = userData as HealthBarEntityData;
            if (healthBarEntityData == null)
            {
                Log.Warning("HealthBarEntityData is not initialized");
            }
        }
    }
}