using System.Collections;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class PlayerFighterLogic : EntityBaseLogic
    {
        [SerializeField] private PlayerFighterData playerFighterData;
        
        private Rigidbody rb;
        
        private Vector2 moveDir;
        private float currentSpeed;
        private float targetSpeed;
        private float speedChangeVelocity; // 用于 SmoothDamp
        private float angelRotate = 25;

        private WaitForSeconds fireInterval;
        private int weaponPower = 3;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            playerFighterData = userData as PlayerFighterData;
            if (playerFighterData == null)
            {
                Log.Warning("PlayerFighterData is not initialized");
            }
            
            rb = GetComponent<Rigidbody>();
            InitData(playerFighterData,false);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            PlayerInputManager.Instance.OnEnable();
            PlayerInputManager.Instance.onMove += PlayerMove;
            PlayerInputManager.Instance.onStopMove += PlayerStopMove;
            PlayerInputManager.Instance.onFire += PlayerFire;
            PlayerInputManager.Instance.onStopFire += PlayerStopFire;

            GameEntry.Entity.ShowThruster(playerFighterData.GetThrusterData);
            for (int i = 0; i < 3; i++)
            {
                GameEntry.Entity.ShowWeaponPoint(playerFighterData.GetWeaponPointDatas[i]);
            }

            fireInterval = new WaitForSeconds(playerFighterData.GetWeaponDatas[0].AttackInterval);
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

            Movement();
            LimiteMove();
            Fire();
        }

        #region Move

        private void PlayerMove(Vector2 direction)
        {
            moveDir = direction;
            targetSpeed = playerFighterData.GetThrusterData.Speed;
        }

        private void PlayerStopMove()
        {
            moveDir=Vector2.zero;
            targetSpeed = 0f; 
        }

        private void Movement()
        {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedChangeVelocity, playerFighterData.ChangeTime);
            rb.velocity = moveDir * currentSpeed;
            Quaternion targetRotation = Quaternion.AngleAxis(angelRotate * moveDir.y, Vector3.right);
            CachedTransform.rotation = Quaternion.Lerp(CachedTransform.rotation, targetRotation, Time.deltaTime / playerFighterData.ChangeTime);
        }

        private void LimiteMove()
        {
            CachedTransform.position = new Vector3(
                Mathf.Clamp(CachedTransform.position.x, -EntityExtension.maxHorizontalDistance, EntityExtension.maxHorizontalDistance),
                Mathf.Clamp(CachedTransform.position.y, EntityExtension.minVerticalDistance, EntityExtension.maxVerticalDistance),
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
                switch (weaponPower)
                {
                    case 1:
                        GameEntry.Entity.ShowWeapon(new WeaponData(GameEntry.Entity.GenerateSerialId(),EnumEntity.PlayerProjectile1)
                        {
                            Position = playerFighterData.GetWeaponPointDatas[0].Position,
                            Rotation = playerFighterData.GetWeaponPointDatas[0].Rotation
                        });
                        break;
                    case 2:
                        GameEntry.Entity.ShowWeapon(new WeaponData(GameEntry.Entity.GenerateSerialId(),EnumEntity.PlayerProjectile1)
                        {
                            Position = playerFighterData.GetWeaponPointDatas[1].Position,
                            Rotation = playerFighterData.GetWeaponPointDatas[1].Rotation
                        });
                        GameEntry.Entity.ShowWeapon(new WeaponData(GameEntry.Entity.GenerateSerialId(),EnumEntity.PlayerProjectile1)
                        {
                            Position = playerFighterData.GetWeaponPointDatas[2].Position,
                            Rotation = playerFighterData.GetWeaponPointDatas[2].Rotation
                        });
                        break;
                    case 3:
                        GameEntry.Entity.ShowWeapon(new WeaponData(GameEntry.Entity.GenerateSerialId(),EnumEntity.PlayerProjectile1)
                        {
                            Position = playerFighterData.GetWeaponPointDatas[0].Position,
                            Rotation = playerFighterData.GetWeaponPointDatas[0].Rotation
                        });
                        GameEntry.Entity.ShowWeapon(new WeaponData(GameEntry.Entity.GenerateSerialId(),EnumEntity.PlayerProjectile2)
                        {
                            Position = playerFighterData.GetWeaponPointDatas[1].Position,
                            Rotation = playerFighterData.GetWeaponPointDatas[1].Rotation
                        });
                        GameEntry.Entity.ShowWeapon(new WeaponData(GameEntry.Entity.GenerateSerialId(),EnumEntity.PlayerProjectile3)
                        {
                            Position = playerFighterData.GetWeaponPointDatas[2].Position,
                            Rotation = playerFighterData.GetWeaponPointDatas[2].Rotation
                        });
                        break;
                }
                yield return fireInterval;
            }
        }

        #endregion
    }
}
