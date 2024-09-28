using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : EntityBaseLogic
    {
        [SerializeField]
        private PlayerFighterData playerFighterData;
        private PlayerInput playerInput;

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
            
            GameEntry.Entity.ShowThruster(playerFighterData.GetThrusterData);
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
            transform.position += playerFighterData.GetThrusterData.Speed * Time.deltaTime * new Vector3(moveDir.x, moveDir.y, 0);
        }
    }
}