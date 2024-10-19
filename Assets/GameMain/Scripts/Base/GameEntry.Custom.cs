
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static DataComponent Data
        {
            get;
            private set;
        }
        private static void InitCustomComponents()
        {
            Data = UnityGameFramework.Runtime.GameEntry.GetComponent<DataComponent>();
        }
    }
}
