using GameFramework;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerMuzzleVFXLogic : MuzzleVFXLogic
    {
        private Material overDriveMaterial;
        private Material defaultMaterial;
        private Renderer muzzleRenderer;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            muzzleRenderer = GetComponent<Renderer>();
            defaultMaterial = muzzleRenderer.material;
            GameEntry.Resource.LoadAsset(
                "Assets/GameMain/Res/Materials/Muzzle/M_Player Muzzle Fire Side Overdrive.mat",
                new LoadAssetCallbacks((assetName, asset, duration, data) => overDriveMaterial = asset as Material));
            
        }

        public void SetOverDriveMaterial()
        {
            muzzleRenderer.material = overDriveMaterial;
        }

        public void SetDefaultMaterial()
        {
            muzzleRenderer.material = defaultMaterial;
        }
    }
}