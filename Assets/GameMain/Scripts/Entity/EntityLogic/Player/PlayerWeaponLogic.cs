using System;
using GameMain.Scripts.Event;
using UnityEngine;

namespace ShootingStar
{
    public class PlayerWeaponLogic : WeaponLogic
    {
        public override void Attack()
        {
            switch (weaponData.WeaponPower)
            {
                case 1:
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                        BulletEntityData.Create(
                            weaponData.IsOverDrive
                                ? EnumEntity.PlayerProjectileOverDrive
                                : EnumEntity.PlayerProjectile, middleMuzzle.position));
                    break;
                case 2:
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                        BulletEntityData.Create(weaponData.IsOverDrive
                            ? EnumEntity.PlayerProjectileOverDrive
                            : EnumEntity.PlayerProjectile, middleMuzzle.position));
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                        BulletEntityData.Create(weaponData.IsOverDrive
                            ? EnumEntity.PlayerProjectileOverDrive
                            : EnumEntity.PlayerProjectile, topMuzzle.position));
                    break;
                case 3:
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                        BulletEntityData.Create(weaponData.IsOverDrive
                            ? EnumEntity.PlayerProjectileOverDrive
                            : EnumEntity.PlayerProjectile, middleMuzzle.position,middleMuzzle.rotation));
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                        BulletEntityData.Create(weaponData.IsOverDrive
                            ? EnumEntity.PlayerProjectileOverDrive
                            : EnumEntity.PlayerProjectile, topMuzzle.position,topMuzzle.rotation));
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                        BulletEntityData.Create(weaponData.IsOverDrive
                            ? EnumEntity.PlayerProjectileOverDrive
                            : EnumEntity.PlayerProjectile, bottomMuzzle.position,bottomMuzzle.rotation));
                    break;
            }
        }

        public void FireMissile()
        {
            weaponData.MissileCount = Mathf.Clamp(weaponData.MissileCount-1,0,10);
            GameEntry.Event.Fire(UpdateMissileCountEventArgs.EventId,UpdateMissileCountEventArgs.Create());
            GameEntry.Entity.ShowEntity<PlayerMissileLogic>(BulletEntityData.Create(EnumEntity.PlayerMissile,
                middleMuzzle.position));
        }
    }
}