using System;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public static class EntityExtension
    {
        public static void ShowPlayerFighter(this EntityComponent entityComponent, PlayerFighterData data)
        {
            entityComponent.ShowEntity(typeof(PlayerLogic), AssetUtility.GetEntityAsset("PlayerFighter"),
                "PlayerFighter", data);
        }

        private static void ShowEntity(this EntityComponent entityComponent, Type typeLogic, string entityAssetName,
            string entityGroupName, EntityData data)
        {
            entityComponent.ShowEntity(data.ID, typeLogic, entityAssetName, entityGroupName, data.Priority, data);
        }
    }
}