using System;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public static class EntityExtension
    {
        public const float maxHorizontalDistance = 8.5f;
        public const float maxVerticalDistance = 5.5f;
        public const float minVerticalDistance = -3.3f;
        
        public static void ShowWeaponPoint(this EntityComponent entityComponent, WeaponPointData pointData)
        {
            entityComponent.ShowEntity(typeof(WeaponPoint), AssetUtility.GetEntityAsset(pointData.AssetName),
                pointData.GroupName, pointData);
        }
        
        public static void ShowThruster(this EntityComponent entityComponent, ThrusterData data)
        {
            entityComponent.ShowEntity(typeof(ThrusterLogic), AssetUtility.GetEntityAsset(data.AssetName),
                data.GroupName, data);
        }
        
        public static void ShowPlayerFighter(this EntityComponent entityComponent, PlayerFighterData data)
        {
            entityComponent.ShowEntity(typeof(PlayerFighterLogic), AssetUtility.GetEntityAsset(data.AssetName),
                data.GroupName, data);
        }

        private static void ShowEntity(this EntityComponent entityComponent, Type typeLogic, string entityAssetName,
            string entityGroupName, EntityData data)
        {
            entityComponent.ShowEntity(data.ID, typeLogic, entityAssetName, entityGroupName, data.Priority, data);
        }
    }
}