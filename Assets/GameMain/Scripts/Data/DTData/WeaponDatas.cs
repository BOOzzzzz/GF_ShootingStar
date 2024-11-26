// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-26 14:06:35.601
//------------------------------------------------------------

using System.Collections.Generic;
using GameFramework.DataTable;

namespace ShootingStar.Data
{
    public class WeaponDatas : BaseDatas
    {
        private IDataTable<DRWeapon> dtWeapon;
        private Dictionary<int, WeaponData> dicWeapon =new Dictionary<int, WeaponData>();

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
        
        public WeaponData GetWeaponData(EnumEntity id)
        {
            return dicWeapon.GetValueOrDefault((int)id);
        }
    }
}