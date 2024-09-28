using System;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class PlayerFighterData:EntityData
    {
        [SerializeField]
        private ThrusterData thrusterData;

        public ThrusterData GetThrusterData
        {
            get => thrusterData;
        }

        public PlayerFighterData(int id) : base(id)
        {
            thrusterData = new ThrusterData(10001, id);
        }
    }
}