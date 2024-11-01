using System;
using GameFramework;
using UnityEngine;
using ShootingStar.Data;

namespace ShootingStar
{
    [Serializable]
    public abstract class EntityBaseData : IReference
    {
        [SerializeField] private int id;
        private Vector3 position;
        private Quaternion rotation;
        
        public EntityData entityData;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public Vector3 Position
        {
            get => position;
            set => position = value;
        }

        public Quaternion Rotation
        {
            get => rotation;
            set => rotation = value;
        }

        public virtual void Clear()
        {
        }
    }
}