// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-25 14:38:43.516
//------------------------------------------------------------

using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.Data
{
    public class EntityDatas : BaseDatas
    {
        private IDataTable<DREntity> dtEntity;
        private Dictionary<int, EntityData> dicEntity =new Dictionary<int, EntityData>();

        public override void Preload()
        {
            LoadDataTable("Entity");
        }

        public override void Load()
        {
            dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity[] drEntitys = dtEntity.GetAllDataRows();
            foreach (var drEntity in drEntitys)
            {
                EntityData entityData = new EntityData(drEntity);
                dicEntity.Add(drEntity.Id,entityData);
            }
        }
        
        public EntityData GetEntityData(EnumEntity id)
        {
            return dicEntity.GetValueOrDefault((int)id);
        }
    }
}