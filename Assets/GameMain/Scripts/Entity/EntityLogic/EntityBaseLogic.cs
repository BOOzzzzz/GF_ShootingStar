using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EntityBaseLogic : EntityLogic
    {
        protected void InitData(EntityBaseData data)
        {
            CachedTransform.position = data.Position;
            CachedTransform.rotation = data.Rotation;
        }
    }
}