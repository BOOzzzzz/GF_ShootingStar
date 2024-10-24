

namespace ShootingStar
{
    public abstract class AccessoryObjectData:EntityBaseData
    {
        private int ownerId;

        public int OwnerId
        {
            get => ownerId;
            set => ownerId = value;
        }

    }
}