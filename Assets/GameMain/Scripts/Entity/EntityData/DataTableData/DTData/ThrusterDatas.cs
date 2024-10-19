using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.DataTableData
{
    public class ThrusterDatas
    {
        private IDataTable<DRThruster> dtThuster;
        private Dictionary<int, ThrusterData> dicWeapon;

        public void LoadAllDatas()
        {
            dtThuster = GameEntry.DataTable.GetDataTable<DRThruster>();
            DRThruster[] drThrusters = dtThuster.GetAllDataRows();
            foreach (var drThruster in drThrusters)
            {
                ThrusterData thrusterData = new ThrusterData(drThruster);
                dicWeapon.Add(drThruster.Id,thrusterData);
            }
        }
    }
}