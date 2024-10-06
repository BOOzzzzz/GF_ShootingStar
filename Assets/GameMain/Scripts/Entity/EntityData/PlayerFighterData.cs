using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class PlayerFighterData : EntityData
    {
        [SerializeField] private float changeTime;

        [SerializeField] private ThrusterData thrusterData;

        private WeaponPointData _weaponPointData;

        public PlayerFighterData(int id) : base(id)
        {
            IDataTable<DRPlayerFighter> dtPlayerFighter = GameEntry.DataTable.GetDataTable<DRPlayerFighter>();
            DRPlayerFighter drPlayerFighter = dtPlayerFighter.GetDataRow(TypeId);
            changeTime = drPlayerFighter.ChangeTime;

            thrusterData = new ThrusterData(20000, id);
            _weaponPointData = new WeaponPointData(30000, id)
            {
                Position = new Vector3(1,0,0)
            };
        }


        public float ChangeTime
        {
            get => changeTime;
            set => changeTime = value;
        }


        public WeaponPointData GetWeaponPointData
        {
            get => _weaponPointData;
        }

        public ThrusterData GetThrusterData
        {
            get => thrusterData;
        }
    }
}