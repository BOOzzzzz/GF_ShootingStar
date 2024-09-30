using System.Collections;
using Unity.Mathematics;
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
        private float angelRotate = 25;

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

            coroutine = StartCoroutine(
                Move(moveDir, Quaternion.AngleAxis(angelRotate * moveDir.y, Vector3.right),
                    playerFighterData.ChangeTime));
        }

        private void PlayerStopMove()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            StartCoroutine(Move(Vector2.zero, Quaternion.identity, playerFighterData.ChangeTime));
        }

        private IEnumerator Move(Vector2 moveDir, Quaternion targetRotation, float changeTime)
        {
            timer = 0;
            while (timer < changeTime)
            {
                timer += Time.deltaTime;
                rb.velocity = Vector3.Lerp(rb.velocity, moveDir * playerFighterData.GetThrusterData.Speed,
                    timer / changeTime);
                CachedTransform.rotation =
                    Quaternion.Lerp(CachedTransform.rotation, targetRotation, timer / changeTime);
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