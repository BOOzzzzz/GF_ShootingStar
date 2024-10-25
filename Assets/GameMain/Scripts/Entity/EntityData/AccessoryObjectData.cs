

using System;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public abstract class AccessoryObjectData:EntityBaseData
    {
        [SerializeField]private int ownerId;

        public int OwnerId
        {
            get => ownerId;
            set => ownerId = value;
        }

    }
}