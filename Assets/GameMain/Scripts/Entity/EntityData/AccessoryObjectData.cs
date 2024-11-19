

using System;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public abstract class AccessoryObjectData:EntityBaseData
    {
        [SerializeField]private int ownerId;
        [SerializeField]private int ownerEntityId;

        public int OwnerId
        {
            get => ownerId;
            set => ownerId = value;
        }
        
        public int OwnerEntityId
        {
            get => ownerEntityId;
            set => ownerEntityId = value;
        }

    }
}