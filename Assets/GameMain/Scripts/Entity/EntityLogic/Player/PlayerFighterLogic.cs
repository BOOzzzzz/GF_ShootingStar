using System.Collections;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : FighterLogic
    {
        private Rigidbody2D rb;

        private Vector2 moveDir;
        private float currentSpeed;
        private float targetSpeed;
        private float speedChangeVelocity; // 用于 SmoothDamp
        private float changeTime = 0.2f;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            fighterEntityData = userData as FighterEntityData;
            if (fighterEntityData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }

            rb = GetComponent<Rigidbody2D>();
            InitData(fighterEntityData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            PlayerInputManager.Instance.OnEnable();
            PlayerInputManager.Instance.onMove += PlayerMove;
            PlayerInputManager.Instance.onStopMove += PlayerStopMove;
            PlayerInputManager.Instance.onFire += PlayerFire;
            PlayerInputManager.Instance.onStopFire += PlayerStopFire;
            PlayerInputManager.Instance.onOverDrive += PlayerOverDrive;
            GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<PlayerWeaponLogic>(fighterEntityData.weaponEntityData);
            GameEntry.Entity.ShowEntity<HealthBarLogic>(HealthBarEntityData.Create(EnumEntity.PlayerHealthBar,transform));
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            PlayerInputManager.Instance.onMove -= PlayerMove;
            PlayerInputManager.Instance.onStopMove -= PlayerStopMove;
            PlayerInputManager.Instance.onFire -= PlayerFire;
            PlayerInputManager.Instance.onStopFire -= PlayerStopFire;
            PlayerInputManager.Instance.onOverDrive -= PlayerOverDrive;
            PlayerInputManager.Instance.OnDisable();
            base.OnHide(isShutdown, userData);
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

        protected override void OnDead()
        {
            base.OnDead();
            GameEntry.Event.Fire(this,GameOverEventArgs.Create());
        }

        #region Move

        private void PlayerMove(Vector2 direction)
        {
            moveDir = direction;
            targetSpeed = fighterEntityData.thrusterEntityData.Speed;
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
                Mathf.Clamp(CachedTransform.position.x, -EntityExtension.MaxHorizontalDistance,
                    EntityExtension.MaxHorizontalDistance),
                Mathf.Clamp(CachedTransform.position.y, EntityExtension.MinVerticalDistance,
                    EntityExtension.MaxVerticalDistance),
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

        #region OverDrive

        public void PlayerOverDrive()
        {
            Log.Debug("Player OverDrive");
            fighterEntityData.weaponEntityData.IsOverDrive = true;
        }

        #endregion
    }
}