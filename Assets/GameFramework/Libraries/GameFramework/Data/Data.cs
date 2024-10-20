namespace GameFramework.Data
{
    public abstract class Data:IData
    {
        public abstract void Preload();

        public abstract void Load();
    }
}