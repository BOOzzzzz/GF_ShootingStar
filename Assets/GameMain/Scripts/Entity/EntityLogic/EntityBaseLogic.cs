using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EntityBaseLogic:EntityLogic
    {
    protected void InitData(EntityBaseData data,bool isAccessoryObject)
    {
        if (isAccessoryObject)
        {
            CachedTransform.localPosition = data.Position;
            CachedTransform.localRotation = data.Rotation;
        }
        else
        {
            CachedTransform.position = data.Position;
            CachedTransform.rotation = data.Rotation;
        }
    }
    }
}