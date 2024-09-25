using System;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public static class EntityExtension
    {
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