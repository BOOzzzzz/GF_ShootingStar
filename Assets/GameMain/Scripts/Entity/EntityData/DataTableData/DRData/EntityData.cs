using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EntityData
    {
        private int id;
        private string assetName;
        private string groupName;
        
        private DREntity drEntity;

        public EntityData(DREntity drEntity)
        {
            this.drEntity=drEntity;
        }

        public int ID
        {
            get => id;
        }

        public string AssetName
        {
            get => assetName;
        }

        public string GroupName
        {
            get => groupName;
        }
    }
}