using System.Collections;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : FighterLogic
    {
        [SerializeField] private FighterEntityData playerFighterEntityData;

        private Rigidbody rb;

        /// <summary>
        /// Move field
        /// </summary>
        private Vector2 moveDir;
        private float currentSpeed;
        private float targetSpeed;
        private float speedChangeVelocity; // 用于 SmoothDamp
        private float angelRotate = 25;
        private float changeTime = 0.2f;

        /// <summary>
        /// Fire field
        /// </summary>
        private WaitForSeconds fireInterval;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            playerFighterEntityData = userData as FighterEntityData;
            if (playerFighterEntityData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }

            rb = GetComponent<Rigidbody>();
            InitData(playerFighterEntityData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            PlayerInputManager.Instance.OnEnable();
            PlayerInputManager.Instance.onMove += PlayerMove;
            PlayerInputManager.Instance.onStopMove += PlayerStopMove;
            PlayerInputManager.Instance.onFire += PlayerFire;
            PlayerInputManager.Instance.onStopFire += PlayerStopFire;
            GameEntry.Entity.ShowEntity<ThrusterLogic>(playerFighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<PlayerWeaponLogic>(playerFighterEntityData.weaponEntityData);
            
            fireInterval = new WaitForSeconds(playerFighterEntityData.weaponEntityData.AttackInterval);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            PlayerInputManager.Instance.onMove -= PlayerMove;
            PlayerInputManager.Instance.onStopMove -= PlayerStopMove;
            PlayerInputManager.Instance.onFire -= PlayerFire;
            PlayerInputManager.Instance.onStopFire -= PlayerStopFire;
            PlayerInputManager.Instance.OnDisable();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            Movement(elapseSeconds);
            LimiteMove();
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            if (childEntity is PlayerWeaponLogic)
            {
                weapon = childEntity as PlayerWeaponLogic;
            }
        }

        #region Move

        private void PlayerMove(Vector2 direction)
        {
            moveDir = direction;
            targetSpeed = playerFighterEntityData.thrusterEntityData.Speed;
        }

        private void PlayerStopMove()
        {
            moveDir = Vector2.zero;
            targetSpeed = 0f;
        }

        private void Movement(float elapseSeconds)
        {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedChangeVelocity,
                changeTime);
            rb.velocity = moveDir * currentSpeed;
            Quaternion targetRotation = Quaternion.AngleAxis(angelRotate * moveDir.y, Vector3.right);
            CachedTransform.rotation = Quaternion.Lerp(CachedTransform.rotation, targetRotation,
                elapseSeconds / changeTime);
        }

        private void LimiteMove()
        {
            CachedTransform.position = new Vector3(
                Mathf.Clamp(CachedTransform.position.x, -EntityExtension.maxHorizontalDistance,
                    EntityExtension.maxHorizontalDistance),
                Mathf.Clamp(CachedTransform.position.y, EntityExtension.minVerticalDistance,
                    EntityExtension.maxVerticalDistance),
                0);
        }

        #endregion

        
        #region Fire
        
        private void PlayerFire()
        {
            StartCoroutine(nameof(Fire));
        }
        
        private void PlayerStopFire()
        {
            StopCoroutine(nameof(Fire));
        }
        
        private IEnumerator Fire()
        {
            while (true)
            {
                weapon.Attack();
                yield return fireInterval;
            }
        }
        
        #endregion
    }
}