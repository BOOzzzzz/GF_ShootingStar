using ShootingStar;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace GameMain.Scripts.UI
{
    public class MenuUILogic : UIFormLogic
    {
        public Button btnStart;
        public Button btnOption;
        public Button btnQuit;

        private Canvas canvas;
        private ProcedureMenu procedureMenu;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            btnStart.onClick.AddListener(StartGame);
            btnOption.onClick.AddListener(OpenOption);
            btnQuit.onClick.AddListener(QuitGame);

            canvas = GetComponent<Canvas>();
            canvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            procedureMenu = userData as ProcedureMenu;
        }

        private void QuitGame()
        {
#if UNITY_EDITOR //在编辑器模式下

            UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
        }

        private void OpenOption()
        {
        }

        private void StartGame()
        {
            procedureMenu.startGame = true;
        }
    }
}