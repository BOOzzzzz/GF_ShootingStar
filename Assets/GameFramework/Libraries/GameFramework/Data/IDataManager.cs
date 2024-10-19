namespace GameFramework.Data
{
    public interface IDataManager
    {
        /// <summary>
        /// 预加载数据表
        /// </summary>
        public void OnPreload();
        /// <summary>
        /// 加载数据表数据
        /// </summary>
        public void OnLoad();
    }
}