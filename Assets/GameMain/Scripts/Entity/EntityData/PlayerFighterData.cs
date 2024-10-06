using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class PlayerFighterData : EntityData
    {
        [SerializeField] private float changeTime;

        [SerializeField] private ThrusterData thrusterData;
        
        [SerializeField] private List<WeaponData> weaponDatas=new List<WeaponData>();

        private WeaponPointData weaponPointData;

        public PlayerFighterData(int entityID,int id) : base(entityID,id)
        {
            IDataTable<DRPlayerFighter> dtPlayerFighter = GameEntry.DataTable.GetDataTable<DRPlayerFighter>();
            DRPlayerFighter drPlayerFighter = dtPlayerFighter.GetDataRow(TypeID);
            changeTime = drPlayerFighter.ChangeTime;

            thrusterData = new ThrusterData(GameEntry.Entity.GenerateSerialId(),20000, entityID);
            weaponPointData = new WeaponPointData(GameEntry.Entity.GenerateSerialId(),30000, entityID)
            {
                Position = new Vector3(1,0,0)
            };
            for (int i = 40000; i < 40001; i++)
            {
                weaponDatas.Add(new WeaponData(GameEntry.Entity.GenerateSerialId(),i));
            }
        }


        public float ChangeTime
        {
            get => changeTime;
            set => changeTime = value;
        }


        public WeaponPointData GetWeaponPointData
        {
            get => weaponPointData;
        }

        public ThrusterData GetThrusterData
        {
            get => thrusterData;
        }
        
        public List<WeaponData> GetWeaponDatas
        {
            get => weaponDatas;
        }
    }
}