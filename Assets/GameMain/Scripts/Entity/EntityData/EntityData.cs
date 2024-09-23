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
            get { return id; }
        }


        public int Priority
        {
            get { return priority; }
        }

        public string AssetName
        {
            get { return assetName; }
        }
        
        public string GroupName
        {
            get { return groupName; }
        }

        public EntityData(int id)
        {
            this.id = id;
            IDataTable<DREntity> dataTable = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity entityData = dataTable.GetDataRow(id);
            assetName = entityData.AssetName;
            groupName = entityData.GroupName;
            priority = entityData.Priority;
        }
    }
}