using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyWeaponLogic : WeaponLogic
    {
        
        public override void Attack()
        {
            switch (weaponData.OwnerEntityId)
            {
                case 1001:
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                        BulletEntityData.Create(EnumEntity.EnemyProjectileBasic, middleMuzzle.position));
                    break;
                case 1002:
                    GameEntry.Entity.ShowEntity<EnemyAimBulletLogic>(
                        BulletEntityData.Create(EnumEntity.EnemyProjectileAiming, middleMuzzle.position));
                    break;
                case 1003:
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                        BulletEntityData.Create(EnumEntity.EnemyProjectile, middleMuzzle.position,middleMuzzle.rotation));
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                        BulletEntityData.Create(EnumEntity.EnemyProjectile, bottomMuzzle.position,bottomMuzzle.rotation));
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                        BulletEntityData.Create(EnumEntity.EnemyProjectile, topMuzzle.position,topMuzzle.rotation));
                    break;
            }
        }
    }
}