using GameFramework;
using GameFramework.Data;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Data")]
    public class DataComponent:GameFrameworkComponent
    {
        private IDataManager m_DataManager = null;

        protected override void Awake()
        {
            base.Awake();
            m_DataManager = GameFrameworkEntry.GetModule<IDataManager>();
            if (m_DataManager == null)
            {
                Log.Fatal("Data manager is invalid.");
                return;
            }
        }

        public void OnPreloadAllDatas()
        {
            m_DataManager.OnPreload();
        }
    }
}