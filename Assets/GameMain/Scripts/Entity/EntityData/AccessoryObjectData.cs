using ShootingStar.ReferencePoolData;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class AccessoryObjectData:EntityBaseData
    {
        private int ownerId;

        public int OwnerId
        {
            get => ownerId;
        }

        protected AccessoryObjectData(int ownerId)
        {
            this.ownerId = ownerId;
        }
    }
}