using System;
using GameFramework;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public abstract class EntityBaseData : IReference
    {
        public int Id { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }

        public virtual void Clear()
        {
        }
    }
}