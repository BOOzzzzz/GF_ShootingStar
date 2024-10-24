using System.Collections.Generic;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace ShootingStar.DataTableData
{
    public class FighterDatas:BaseDatas
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
            return dicFighter[(int)id];
        }
    }
}