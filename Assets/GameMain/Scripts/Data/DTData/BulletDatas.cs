using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.DataTableData
{
    public class BulletDatas:BaseDatas
    {
        private IDataTable<DRBullet> dtBullet;
        private Dictionary<int, BulletData> dicBullet = new Dictionary<int, BulletData>();

        public override void Preload()
        {
            LoadDataTable("Bullet");
        }

        public override void Load()
        {
            dtBullet = GameEntry.DataTable.GetDataTable<DRBullet>();
            DRBullet[] drBullets = dtBullet.GetAllDataRows();
            foreach (var drBullet in drBullets)
            {
                BulletData bulletData = new BulletData(drBullet);
                dicBullet.Add(drBullet.Id,bulletData);
            }
        }
        
        public BulletData GetBulletData(EnumEntity id)
        {
            return dicBullet.TryGetValue((int)id, out BulletData bulletData)? bulletData : null;
        }
    }
}