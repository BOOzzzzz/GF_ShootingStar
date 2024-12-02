using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class UIFormBaseLogic:UIFormLogic
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