// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-26 14:06:35.599
//------------------------------------------------------------

using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.Data
{
    public class ThrusterDatas : BaseDatas
    {
        private IDataTable<DRThruster> dtThruster;
        private Dictionary<int, ThrusterData> dicThruster =new Dictionary<int, ThrusterData>();

        public override void Preload()
        {
            LoadDataTable("Thruster");
        }

        public override void Load()
        {
            dtThruster = GameEntry.DataTable.GetDataTable<DRThruster>();
            DRThruster[] drThrusters = dtThruster.GetAllDataRows();
            foreach (var drThruster in drThrusters)
            {
                ThrusterData thrusterData = new ThrusterData(drThruster);
                dicThruster.Add(drThruster.Id,thrusterData);
            }
        }
        
        public ThrusterData GetThrusterData(EnumEntity id)
        {
            return dicThruster.GetValueOrDefault((int)id);
        }
    }
}