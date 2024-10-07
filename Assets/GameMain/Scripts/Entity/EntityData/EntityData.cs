using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class EntityData
    {
        private int entityID;

        private int id;
        private int priority;
        private string assetName;
        private string groupName;
        private Vector3 position;
        private Quaternion rotation;



        public int EntityID
        {
            get => entityID;
        }

        public int ID
        {
            get => id;
        }

        public int Priority
        {
            get => priority;
        }

        public string AssetName
        {
            get => assetName;
        }

        public string GroupName
        {
            get => groupName;
        }

        public Vector3 Position
        {
            get => position;
            set => position = value;
        }

        public Quaternion Rotation
        {
            get => rotation;
            set => rotation = value;
        }

        public EntityData(int entityID,int id)
        {
            this.id = id;
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(id);
            this.entityID = entityID;
            assetName = drEntity.AssetName;
            groupName = drEntity.GroupName;
            priority = drEntity.Priority;
        }
    }
}