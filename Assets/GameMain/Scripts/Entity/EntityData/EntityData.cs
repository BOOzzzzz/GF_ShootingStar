namespace ShootingStar
{
    public abstract class EntityData
    {
        private int id;
        private int typeID;
        private int priority;


        public int ID
        {
            get { return id; }
        }
        
        public int TypeID
        {
            get { return typeID; }
        }
        
        public int Priority
        {
            get { return priority; }
        }

        public EntityData(int id, int typeID, int priority)
        {
            this.id = id;
            this.typeID = typeID;
            this.priority = priority;
        }
    }
}