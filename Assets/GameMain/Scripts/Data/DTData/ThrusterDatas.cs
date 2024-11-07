// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-07 10:30:31.018
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
            return dicThruster.TryGetValue((int)id, out ThrusterData entityData)? entityData : null;
        }
    }
}