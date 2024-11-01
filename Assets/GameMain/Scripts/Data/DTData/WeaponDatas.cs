// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-11-01 11:38:46.540
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
            return dicWeapon.TryGetValue((int)id, out WeaponData entityData)? entityData : null;
        }
    }
}