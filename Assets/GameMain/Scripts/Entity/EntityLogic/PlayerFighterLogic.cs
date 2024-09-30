using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : EntityBaseLogic
    {
        [SerializeField] private PlayerFighterData playerFighterData;

        private Rigidbody rb;

        private float timer;
        private Coroutine coroutine;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            playerFighterData = userData as PlayerFighterData;
            if (playerFighterData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }

            rb = GetComponent<Rigidbody>();

            InitData(playerFighterData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            PlayerInputManager.Instance.OnEnable();
            PlayerInputManager.Instance.onMove += PlayerMove;
            PlayerInputManager.Instance.onStopMove += PlayerStopMove;

            GameEntry.Entity.ShowThruster(playerFighterData.GetThrusterData);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            PlayerInputManager.Instance.onMove -= PlayerMove;
            PlayerInputManager.Instance.onStopMove -= PlayerStopMove;
            PlayerInputManager.Instance.OnDisable();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            Log.Debug(rb.velocity);
            LimiteMove();
        }

        private void PlayerMove(Vector2 moveDir)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            coroutine = StartCoroutine(Move(moveDir, 0.2f));
        }

        private void PlayerStopMove()
        {
            if (coroutine!=null)
            {
                StopCoroutine(coroutine);
            }
            StartCoroutine(Move(Vector2.zero, 0.2f));
        }

        private IEnumerator Move(Vector2 moveDir, float changeVelocityTime)
        {
            timer = 0;
            while (timer < changeVelocityTime)
            {
                timer += Time.deltaTime;
                rb.velocity = Vector3.Lerp(rb.velocity, moveDir * playerFighterData.GetThrusterData.Speed,
                    timer / changeVelocityTime);
                yield return null;
            }
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