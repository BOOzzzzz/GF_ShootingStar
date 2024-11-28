using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShootingStar.Data;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public static class EntityExtension
    {
        public static int serialID = 0;

        public const float MaxHorizontalDistance = 8.5f;
        public const float MaxVerticalDistance = 5.5f;
        public const float MinVerticalDistance = -3.3f;

        public static void HideEntity(this EntityComponent entityComponent, EntityLogic entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static int ShowEntity<T>(this EntityComponent entityComponent, EntityBaseData data)
            where T : EntityBaseLogic
        {
            if (!entityComponent.HasEntityGroup(data.entityData.GroupName))
            {
                PoolParamData poolParamData = GameEntry.Data.GetData<PoolParamDatas>()
                    .GetPoolParamData(data.entityData.PoolParamID);
                entityComponent.AddEntityGroup(data.entityData.GroupName, poolParamData.InstanceAutoReleaseInterval,
                    poolParamData.InstanceCapacity, poolParamData.InstanceExpireTime, poolParamData.InstancePriority);
            }
            
            GameEntry.Entity.ShowEntity(typeof(T), AssetUtility.GetEntityAsset(data.entityData.AssetName),
                data.entityData.GroupName, data);
            return data.Id;
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