// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-01 23:05:25.435
//------------------------------------------------------------

using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.Data
{
    public class FighterDatas : BaseDatas
    {
        private IDataTable<DRFighter> dtFighter;
        private Dictionary<int, FighterData> dicFighter =new Dictionary<int, FighterData>();

        public override void Preload()
        {
            LoadDataTable("Fighter");
        }

        public override void Load()
        {
            dtFighter = GameEntry.DataTable.GetDataTable<DRFighter>();
            DRFighter[] drFighters = dtFighter.GetAllDataRows();
            foreach (var drFighter in drFighters)
            {
                FighterData fighterData = new FighterData(drFighter);
                dicFighter.Add(drFighter.Id,fighterData);
            }
        }
        
        public FighterData GetFighterData(EnumEntity id)
        {
            return dicFighter.TryGetValue((int)id, out FighterData entityData)? entityData : null;
        }
    }
}