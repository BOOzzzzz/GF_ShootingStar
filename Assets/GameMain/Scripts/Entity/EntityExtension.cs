using System;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public static class EntityExtension
    {
        public static int serialID = 0;

        public const float maxHorizontalDistance = 8.5f;
        public const float maxVerticalDistance = 5.5f;
        public const float minVerticalDistance = -3.3f;

        public static void HideEntity(this EntityComponent entityComponent, EntityLogic entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }
        
        public static void ShowBullet(this EntityComponent entityComponent, BulletEntityData data)
        {
            entityComponent.ShowEntity(typeof(BulletLogic),
                AssetUtility.GetEntityAsset(data.entityData.AssetName),
                data.entityData.GroupName, data);
        }

        public static void ShowWeapon(this EntityComponent entityComponent, WeaponEntityData data)
        {
            entityComponent.ShowEntity(typeof(WeaponLogic),
                AssetUtility.GetEntityAsset(data.entityData.AssetName),
                data.entityData.GroupName, data);
        }

        public static void ShowThruster(this EntityComponent entityComponent, ThrusterEntityData data)
        {
            entityComponent.ShowEntity(typeof(ThrusterLogic),
                AssetUtility.GetEntityAsset(data.entityData.AssetName),
                data.entityData.GroupName, data);
        }

        public static void ShowPlayerFighter(this EntityComponent entityComponent, FighterEntityData data)
        {
            entityComponent.ShowEntity(typeof(PlayerFighterLogic),
                AssetUtility.GetEntityAsset(data.entityData.AssetName),
                data.entityData.GroupName, data);
        }

        public static void ShowEntity(this EntityComponent entityComponent, Type typeLogic, string assetName,
            string groupName, object userData)
        {
            entityComponent.ShowEntity(((EntityBaseData)userData).Id, typeLogic, assetName,
                groupName, userData);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return ++serialID;
        }
    }
}