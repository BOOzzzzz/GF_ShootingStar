using System;
using UnityEngine;

namespace ShootingStar
{
    public class PlayerWeaponLogic : WeaponLogic
    {
        private Transform middleMuzzle;
        private Transform topMuzzle;
        private Transform bottomMuzzle;

        private Type bulletLogicType;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            middleMuzzle = transform.Find("middleMuzzle").transform;
            topMuzzle = transform.Find("topMuzzle").transform;
            bottomMuzzle = transform.Find("bottomMuzzle").transform;
        }

        public override void Attack()
        {
            if (weaponData.IsOverDrive)
            {
                // 当武器处于OverDrive状态时
                switch (weaponData.WeaponPower)
                {
                    case 1:
                        GameEntry.Entity.ShowEntity<PlayerOverDriveBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectileOverDrive, middleMuzzle.position));
                        break;
                    case 2:
                        GameEntry.Entity.ShowEntity<PlayerOverDriveBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectileOverDrive, middleMuzzle.position));
                        GameEntry.Entity.ShowEntity<PlayerOverDriveBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectileOverDrive, topMuzzle.position));
                        break;
                    case 3:
                        GameEntry.Entity.ShowEntity<PlayerOverDriveBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectileOverDrive, middleMuzzle.position));
                        GameEntry.Entity.ShowEntity<PlayerOverDriveBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectileOverDrive, topMuzzle.position));
                        GameEntry.Entity.ShowEntity<PlayerOverDriveBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectileOverDrive, bottomMuzzle.position));
                        break;
                }
            }
            else
            {
                // 当武器不处于OverDrive状态时
                switch (weaponData.WeaponPower)
                {
                    case 1:
                        GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectile1, middleMuzzle.position));
                        break;
                    case 2:
                        GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectile1, middleMuzzle.position));
                        GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectile1, topMuzzle.position));
                        break;
                    case 3:
                        GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectile1, middleMuzzle.position));
                        GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectile2, topMuzzle.position));
                        GameEntry.Entity.ShowEntity<PlayerBulletLogic>(
                            BulletEntityData.Create(EnumEntity.PlayerProjectile3, bottomMuzzle.position));
                        break;
                }
            }
        }
    }
}