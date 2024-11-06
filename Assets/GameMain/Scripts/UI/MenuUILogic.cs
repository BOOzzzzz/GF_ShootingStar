using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Scripts.UI
{
    public class MenuUILogic:UIFormLogic
    {
        private Canvas canvas;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            canvas = GetComponent<Canvas>();
            canvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
        
        
    }
}