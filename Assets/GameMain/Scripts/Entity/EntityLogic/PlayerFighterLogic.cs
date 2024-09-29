using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : EntityBaseLogic
    {
        [SerializeField] 
        private PlayerFighterData playerFighterData;
        private PlayerInput playerInput;
        private Rigidbody rb;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            playerFighterData = userData as PlayerFighterData;
            if (playerFighterData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }

            playerInput = new PlayerInput();
            rb = GetComponent<Rigidbody>();

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
            LimiteMove();
        }

        private void PlayerMove(Vector2 moveDir)
        {
            rb.velocity = moveDir * playerFighterData.GetThrusterData.Speed;
        }

        private void LimiteMove()
        {
            CachedTransform.position = new Vector3(
                Mathf.Clamp(CachedTransform.position.x, -EntityExtension.maxHorizontalDistance,
                    EntityExtension.maxHorizontalDistance),
                Mathf.Clamp(CachedTransform.position.y, EntityExtension.minVerticalDistance,
                    EntityExtension.maxVerticalDistance), 0);
        }
    }
}