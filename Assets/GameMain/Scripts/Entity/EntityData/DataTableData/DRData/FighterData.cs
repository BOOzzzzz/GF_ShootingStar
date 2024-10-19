using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    public class FighterData
    {
        private DRFighter drFighter;

        public FighterData(DRFighter drFighter)
        {
            this.drFighter=drFighter;
        }

        public int ID
        {
            get => drFighter.Id;
        }

        public float ChangeTime
        {
            get => drFighter.ChangeTime;
        }
    }
}