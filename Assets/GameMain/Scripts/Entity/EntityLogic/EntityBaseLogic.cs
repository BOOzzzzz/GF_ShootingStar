using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EntityBaseLogic:EntityLogic
    {
        
        protected void InitData(EntityData data)
        {
            CachedTransform.localPosition = data.Position;
            CachedTransform.localRotation = data.Rotation;
        }
    }
}