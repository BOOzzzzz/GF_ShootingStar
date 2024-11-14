using UnityEngine;

namespace ShootingStar
{
    public class PlayerWeaponLogic : WeaponLogic
    {
        private Transform middleMuzzle;
        private Transform topMuzzle;
        private Transform bottomMuzzle;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            middleMuzzle = transform.Find("middleMuzzle").transform;
            topMuzzle = transform.Find("topMuzzle").transform;
            bottomMuzzle = transform.Find("bottomMuzzle").transform;
        }

        public override void Attack()
        {
            switch (weaponData.WeaponPower)
            {
                case 1:
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(BulletEntityData.Create(
                        weaponData.IsOverDrive ? EnumEntity.PlayerProjectile1 : EnumEntity.PlayerProjectileOverDrive,
                        middleMuzzle.position));
                    break;
                case 2:

                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(BulletEntityData.Create(
                        weaponData.IsOverDrive ? EnumEntity.PlayerProjectile1 : EnumEntity.PlayerProjectileOverDrive,
                        middleMuzzle.position));
                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(BulletEntityData.Create(
                        weaponData.IsOverDrive ? EnumEntity.PlayerProjectile1 : EnumEntity.PlayerProjectileOverDrive,
                        topMuzzle.position));
                    break;
                case 3:

                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(BulletEntityData.Create(
                        weaponData.IsOverDrive ? EnumEntity.PlayerProjectile1 : EnumEntity.PlayerProjectileOverDrive,
                        middleMuzzle.position));

                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(BulletEntityData.Create(
                        weaponData.IsOverDrive ? EnumEntity.PlayerProjectile2 : EnumEntity.PlayerProjectileOverDrive,
                        topMuzzle.position));

                    GameEntry.Entity.ShowEntity<PlayerBulletLogic>(BulletEntityData.Create(
                        weaponData.IsOverDrive ? EnumEntity.PlayerProjectile3 : EnumEntity.PlayerProjectileOverDrive,
                        bottomMuzzle.position));
                    break;
            }
        }
    }
}