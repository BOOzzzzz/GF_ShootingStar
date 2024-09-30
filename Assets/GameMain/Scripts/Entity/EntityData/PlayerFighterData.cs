using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class PlayerFighterData:EntityData
    {
        [SerializeField] 
        private float changeTime;

        [SerializeField]
        private ThrusterData thrusterData;

        public ThrusterData GetThrusterData
        {
            get => thrusterData;
        }

        public PlayerFighterData(int id) : base(id)
        {
            IDataTable<DRPlayerFighter> dtPlayerFighter = GameEntry.DataTable.GetDataTable<DRPlayerFighter>();
            DRPlayerFighter drPlayerFighter = dtPlayerFighter.GetDataRow(TypeId);
            changeTime = drPlayerFighter.ChangeTime;
            
            thrusterData = new ThrusterData(10001, id);
        }
        
        
        public float ChangeTime
        {
            get => changeTime;
            set => changeTime = value;
        }
    }
}