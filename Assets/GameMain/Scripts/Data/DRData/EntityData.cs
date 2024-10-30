using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EntityData
    {
        private DREntity drEntity;

        public EntityData(DREntity drEntity)
        {
            this.drEntity=drEntity;
        }

        public int ID
        {
            get => drEntity.Id;
        }

        public string AssetName
        {
            get => drEntity.AssetName;
        }

        public string GroupName
        {
            get => drEntity.GroupName;
        }
    }
}