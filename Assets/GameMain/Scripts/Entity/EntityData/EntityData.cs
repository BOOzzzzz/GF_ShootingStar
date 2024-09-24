using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    public abstract class EntityData
    {
        private int id;
        private int typeId;
        private int priority;
        private string assetName;
        private string groupName;
        private Vector3 position;
        private Quaternion rotation;



        public int ID
        {
            get => id;
        }

        public int TypeId
        {
            get => typeId;
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

        public EntityData(int id)
        {
            this.id = id;
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(id);
            typeId = drEntity.TypeId;
            assetName = drEntity.AssetName;
            groupName = drEntity.GroupName;
            priority = drEntity.Priority;
        }
    }
}