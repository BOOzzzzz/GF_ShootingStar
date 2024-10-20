using System;

namespace GameFramework.Data
{
    public interface IDataManager
    {
        public void AddData(Data data);
        
        public Data GetData(Type type);

        public T GetData<T>() where T : Data;
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