using System;
using System.Collections;
using UnityEngine;

namespace ShootingStar
{
    public class CoroutineRunner:MonoBehaviour
    {
        private static CoroutineRunner instance;

        public static CoroutineRunner Instance => instance;

        private void Awake()
        {
            instance = this;
        }
        
        public Coroutine StartCoroutineRunner(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
        
        public void StopCoroutineRunner(IEnumerator coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}