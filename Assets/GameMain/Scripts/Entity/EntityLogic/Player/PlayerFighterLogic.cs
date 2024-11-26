using System;
using System.Collections;
using GameFramework.Event;
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
        private WaitForSeconds attenuationInterval = new(0.15f);

        private PlayerMuzzleVFXLogic playerMuzzleVFXLogic;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            rb = GetComponent<Rigidbody2D>();
        }

        protected override void OnShow(object userData)
        {
            fighterEntityData = userData as FighterEntityData;
            if (fighterEntityData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }
            InitData(fighterEntityData);
            
            base.OnShow(userData);

            PlayerInputManager.Instance.OnEnable();
            PlayerInputManager.Instance.onMove += PlayerMove;
            PlayerInputManager.Instance.onStopMove += PlayerStopMove;
            PlayerInputManager.Instance.onFire += PlayerFire;
            PlayerInputManager.Instance.onStopFire += PlayerStopFire;
            PlayerInputManager.Instance.onOverDrive += PlayerOverDrive;
            PlayerInputManager.Instance.onFireMissile += PlayerFireMissile;

            GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<PlayerWeaponLogic>(fighterEntityData.weaponEntityData);
            GameEntry.Entity.ShowEntity<HealthBarLogic>(HealthBarEntityData.Create(EnumEntity.PlayerHealthBar,
                transform));
            GameEntry.Entity.ShowEntity<PlayerMuzzleVFXLogic>(
                VFXAccessoryEntityData.Create(EnumEntity.VFXPlayerMuzzleFire, fighterEntityData.Id));

            GameEntry.Event.Subscribe(AddEnergyEventArgs.EventId, AddEnergyValue);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            PlayerInputManager.Instance.onMove -= PlayerMove;
            PlayerInputManager.Instance.onStopMove -= PlayerStopMove;
            PlayerInputManager.Instance.onFire -= PlayerFire;
            PlayerInputManager.Instance.onStopFire -= PlayerStopFire;
            PlayerInputManager.Instance.onOverDrive -= PlayerOverDrive;
            PlayerInputManager.Instance.onFireMissile -= PlayerFireMissile;
            PlayerInputManager.Instance.OnDisable();

            GameEntry.Event.Unsubscribe(AddEnergyEventArgs.EventId, AddEnergyValue);

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

            if (childEntity is PlayerWeaponLogic playerWeaponLogic)
            {
                weaponLogic = playerWeaponLogic;
            }

            if (childEntity is PlayerMuzzleVFXLogic muzzleVFXLogic)
            {
                playerMuzzleVFXLogic = muzzleVFXLogic;
            }
        }

        protected override void OnDead()
        {
            base.OnDead();
            GameEntry.Event.Fire(this, GameOverEventArgs.Create());
            GameEntry.Entity.ShowEntity<VFXLogic>(VFXEntityData.Create(EnumEntity.VFXPlayerDeath,
                CachedTransform.position, CachedTransform.rotation));
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
            playerMuzzleVFXLogic.muzzleParticleSystem.Play();
            StartCoroutine(nameof(Fire));
        }

        private void PlayerStopFire()
        {
            playerMuzzleVFXLogic.muzzleParticleSystem.Stop();
            StopCoroutine(nameof(Fire));
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                weaponLogic.Attack();
                yield return fireInterval;
            }
        }

        private void PlayerFireMissile()
        {
            if (fighterEntityData.weaponEntityData.MissileCount > 0)
            {
                (weaponLogic as PlayerWeaponLogic)?.FireMissile();
            }
        }

        #endregion

        #region OverDrive

        private void PlayerOverDrive()
        {
            if (Math.Abs(fighterEntityData.Energy - fighterEntityData.MaxEnergy) < 0.1f)
            {
                Log.Debug("Player OverDrive");
                playerMuzzleVFXLogic.SetOverDriveMaterial();
                GameEntry.Entity.HideEntity(fighterEntityData.thrusterEntityData.Id);
                fighterEntityData.thrusterEntityData = ThrusterEntityData.Create(EnumEntity.PlayerThrusterOverDrive, fighterEntityData.Id);
                GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
                GameEntry.Entity.ShowEntity<VFXLogic>(VFXEntityData.Create(EnumEntity.VFXOverdriveTrigger,
                    CachedTransform.position, CachedTransform.rotation, Entity));
                StartCoroutine(EnergyBurstDecayCoroutine());
            }
        }

        private IEnumerator EnergyBurstDecayCoroutine()
        {
            fighterEntityData.weaponEntityData.IsOverDrive = true;
            while (fighterEntityData.Energy > 0.1f)
            {
                fighterEntityData.Energy = Mathf.Clamp(fighterEntityData.Energy -= 1, 0, fighterEntityData.MaxEnergy);
                updateEnergyBar?.Invoke(false);
                yield return attenuationInterval;
            }

            fighterEntityData.weaponEntityData.IsOverDrive = false;
            playerMuzzleVFXLogic.SetDefaultMaterial();
            GameEntry.Entity.HideEntity(fighterEntityData.thrusterEntityData.Id);
            fighterEntityData.thrusterEntityData = ThrusterEntityData.Create(EnumEntity.PlayerThruster, fighterEntityData.Id);
            GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
        }

        private void AddEnergyValue(object sender, GameEventArgs e)
        {
            AddEnergyEventArgs ne = e as AddEnergyEventArgs;
            if (ne == null)
            {
                return;
            }

            fighterEntityData.Energy =
                Mathf.Clamp(fighterEntityData.Energy + ne.EnergyValue, 0, fighterEntityData.MaxEnergy);
            updateEnergyBar?.Invoke(true);
        }

        #endregion
    }
}