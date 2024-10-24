using System.Collections.Generic;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace ShootingStar.DataTableData
{
    public class EntityDatas:BaseDatas
    {
        private IDataTable<DREntity> dtEntity;
        private Dictionary<int, EntityData> dicEntity = new Dictionary<int, EntityData>();

        public override void Preload()
        {
            LoadDataTable("Entity");
        }

        public override void Load()
        {
            dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity[] drEntities = dtEntity.GetAllDataRows();
            foreach (var drEntity in drEntities)
            {
                EntityData entityData = new EntityData(drEntity);
                dicEntity.Add(drEntity.Id,entityData);
            }
        }
        
        public EntityData GetEntityData(EnumEntity id)
        {
            return dicEntity[(int)id];
        }
    }
}