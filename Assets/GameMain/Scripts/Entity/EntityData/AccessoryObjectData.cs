using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class AccessoryObjectData:EntityData
    {
        private int ownerId;

        public int OwnerId
        {
            get => ownerId;
        }

        protected AccessoryObjectData(int entityID,int id,int ownerId) : base(entityID,id)
        {
            this.ownerId = ownerId;
        }
    }
}