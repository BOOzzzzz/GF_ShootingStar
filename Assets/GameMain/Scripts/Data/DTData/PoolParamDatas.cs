// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-28 22:58:25.970
//------------------------------------------------------------

using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.Data
{
    public class PoolParamDatas : BaseDatas
    {
        private IDataTable<DRPoolParam> dtPoolParam;
        private Dictionary<int, PoolParamData> dicPoolParam =new Dictionary<int, PoolParamData>();

        public override void Preload()
        {
            LoadDataTable("PoolParam");
        }

        public override void Load()
        {
            dtPoolParam = GameEntry.DataTable.GetDataTable<DRPoolParam>();
            DRPoolParam[] drPoolParams = dtPoolParam.GetAllDataRows();
            foreach (var drPoolParam in drPoolParams)
            {
                PoolParamData poolparamData = new PoolParamData(drPoolParam);
                dicPoolParam.Add(drPoolParam.Id,poolparamData);
            }
        }
        
        public PoolParamData GetPoolParamData(EnumEntity id)
        {
            return dicPoolParam.GetValueOrDefault((int)id);
        }
        
        public PoolParamData GetPoolParamData(int id)
        {
            return dicPoolParam.GetValueOrDefault(id);
        }
    }
}