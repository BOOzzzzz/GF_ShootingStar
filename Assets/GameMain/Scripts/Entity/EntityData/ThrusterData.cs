namespace ShootingStar
{
    public class ThrusterData:AccessoryObjectData
    {
        private float speed;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public ThrusterData(int id, int ownerId) : base(id, ownerId)
        {
        }
    }
}