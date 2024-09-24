using GameFramework.DataTable;

namespace ShootingStar
{
    public abstract class EntityData
    {
        private int id;
        private int priority;
        private string assetName;
        private string groupName;


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

        public EntityData(int id)
        {
            this.id = id;
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(id);
            assetName = drEntity.AssetName;
            groupName = drEntity.GroupName;
            priority = drEntity.Priority;
        }
    }
}