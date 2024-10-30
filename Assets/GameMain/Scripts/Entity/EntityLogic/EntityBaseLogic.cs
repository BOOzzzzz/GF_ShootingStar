using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class EntityBaseLogic : EntityLogic
    {
        protected void InitData(EntityBaseData data)
        {
            CachedTransform.localPosition = data.Position;
            CachedTransform.localRotation = data.Rotation;
        }
    }
}