using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.DataTableData
{
    public class FighterDatas
    {
        private IDataTable<DRFighter> dtFighter;
        private Dictionary<int, FighterData> dicEntity;

        public void LoadAllDatas()
        {
            dtFighter = GameEntry.DataTable.GetDataTable<DRFighter>();
            DRFighter[] drFighters = dtFighter.GetAllDataRows();
            foreach (var drFighter in drFighters)
            {
                FighterData fighterData = new FighterData(drFighter);
                dicEntity.Add(drFighter.Id,fighterData);
            }
        }
    }
}