using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.DataTableData
{
    public class EntityDatas:BaseDatas
    {
        private IDataTable<DREntity> dtEntity;
        private Dictionary<int, EntityData> dicEntity;

        public override void OnPreload()
        {
            LoadDataTable("Entity");
        }

        public override void OnLoad()
        {
            dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity[] drEntities = dtEntity.GetAllDataRows();
            foreach (var drEntity in drEntities)
            {
                EntityData entityData = new EntityData(drEntity);
                dicEntity.Add(drEntity.Id,entityData);
            }
        }
    }
}