using System.Collections.Generic;

namespace GameFramework.Data
{
    public class DataManager:IDataManager
    {
        public List<Data> datas = new List<Data>();
        public void OnPreload()
        {
            foreach (var data in datas)
            {
                data.OnPreload();
            }
        }

        public void OnLoad()
        {
            foreach (var data in datas)
            {
                data.OnLoad();
            }
        }
    }
}