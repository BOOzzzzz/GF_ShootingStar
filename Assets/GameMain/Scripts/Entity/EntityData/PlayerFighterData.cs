using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    public class PlayerFighterData:EntityData
    {
        public Dictionary<int,ThrusterData> thrusters = new Dictionary<int,ThrusterData>();
        public PlayerFighterData(int id) : base(id)
        {
            thrusters[10001] = new ThrusterData(10001, id)
            {
                Position = new Vector3(-0.87f, -0.05f, 0)
            };

            thrusters[10002] = new ThrusterData(10002, id)
            {
                Position = new Vector3(-0.75f, -0.154f, 0.242f)
            };

            thrusters[10003] = new ThrusterData(10003, id)
            {
                Position = new Vector3(-0.75f, -0.154f, -0.242f)
            };
        }
    }
}