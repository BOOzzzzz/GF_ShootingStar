
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class GameSurvive : GameBase
    {
        public override void Initialize()
        {
            base.Initialize();
            Log.Debug("GameSurvive");
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);

            if (Input.GetKeyDown(KeyCode.M))
            {
                enemyEntityLoader.SpawnEnemies(5);
            }
        }
    }
}
