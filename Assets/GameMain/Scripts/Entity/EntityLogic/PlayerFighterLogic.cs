using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : EntityBaseLogic
    {
        private PlayerFighterData playerFighterData;
        private PlayerInput playerInput;
        public float speed = 5f;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            playerFighterData = userData as PlayerFighterData;
            if (playerFighterData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }

            playerInput = new PlayerInput();
            
            InitData(playerFighterData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            playerInput.Enable();
            for (int i = 1; i <= 3; i++)
            {
                GameEntry.Entity.ShowThruster(playerFighterData.thrusters[10000+i]);
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            playerInput.Disable();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            var moveDir = playerInput.GamePlay.Move.ReadValue<Vector2>();
            
            PlayerMove(moveDir);
        }

        private void PlayerMove(Vector2 moveDir)
        {
            transform.position += speed * Time.deltaTime * new Vector3(moveDir.x,moveDir.y,0);
        }
    }
}