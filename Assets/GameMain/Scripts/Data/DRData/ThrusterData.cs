using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    public class ThrusterData
    {
        private DRThruster drThruster;

        public ThrusterData(DRThruster drThruster)
        {
            this.drThruster=drThruster;
        }

        public int ID
        {
            get => drThruster.Id;
        }

        public float Speed
        {
            get => drThruster.Speed;
        }
    }
}