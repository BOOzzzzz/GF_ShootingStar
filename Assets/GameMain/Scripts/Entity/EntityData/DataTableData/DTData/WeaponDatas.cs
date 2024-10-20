using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.DataTableData
{
    public class WeaponDatas:BaseDatas
    {
        private IDataTable<DRWeapon> dtWeapon;
        private Dictionary<int, WeaponData> dicWeapon;

        public override void Preload()
        {
            LoadDataTable("Weapon");
        }

        public override void Load()
        {
            dtWeapon = GameEntry.DataTable.GetDataTable<DRWeapon>();
            DRWeapon[] drWeapons = dtWeapon.GetAllDataRows();
            foreach (var drWeapon in drWeapons)
            {
                WeaponData weaponData = new WeaponData(drWeapon);
                dicWeapon.Add(drWeapon.Id,weaponData);
            }
        }
        
        public WeaponData GetThrusterData(EnumEntity id)
        {
            return dicWeapon.TryGetValue((int)id, out WeaponData weaponData)? weaponData : null;
        }
    }
}