using System;
using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    [Serializable]
    public class ThrusterData:AccessoryObjectData
    {
        [SerializeField]
        private float speed;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public ThrusterData(int entityID,EnumEntity id, int ownerId) : base(entityID,(int)id, ownerId)
        {
            IDataTable<DRThruster> dtThruster = GameEntry.DataTable.GetDataTable<DRThruster>();
            DRThruster drThruster = dtThruster.GetDataRow((int)id);
            speed = drThruster.Speed;
        }
    }
}