using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.DataTableData
{
    public class WeaponDatas
    {
        private IDataTable<DRWeapon> dtWeapon;
        private Dictionary<int, WeaponData> dicWeapon;

        public void LoadAllDatas()
        {
            dtWeapon = GameEntry.DataTable.GetDataTable<DRWeapon>();
            DRWeapon[] drWeapons = dtWeapon.GetAllDataRows();
            foreach (var drWeapon in drWeapons)
            {
                WeaponData weaponData = new WeaponData(drWeapon);
                dicWeapon.Add(drWeapon.Id,weaponData);
            }
        }
    }
}