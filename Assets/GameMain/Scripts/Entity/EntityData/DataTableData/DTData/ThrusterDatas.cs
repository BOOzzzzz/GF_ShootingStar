using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.DataTableData
{
    public class ThrusterDatas:BaseDatas
    {
        private IDataTable<DRThruster> dtThuster;
        private Dictionary<int, ThrusterData> dicThuster;

        public override void Preload()
        {
            LoadDataTable("Thruster");
        }

        public override void Load()
        {
            dtThuster = GameEntry.DataTable.GetDataTable<DRThruster>();
            DRThruster[] drThrusters = dtThuster.GetAllDataRows();
            foreach (var drThruster in drThrusters)
            {
                ThrusterData thrusterData = new ThrusterData(drThruster);
                dicThuster.Add(drThruster.Id,thrusterData);
            }
        }
        
        public ThrusterData GetThrusterData(EnumEntity id)
        {
            return dicThuster.TryGetValue((int)id, out ThrusterData thrusterData)? thrusterData : null;
        }
        
    }
}