using System;
using System.Collections;
using GameFramework.Event;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class WaveUILogic : UIFormBaseLogic
    {
        private Text waveText;
        private int waveNum;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            waveText = GetComponentInChildren<Text>();
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            waveNum = (int)userData;
            waveText.text = $"- WAVE {waveNum} -";
        }
    }
}