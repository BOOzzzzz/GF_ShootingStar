using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyWeaponLogic : WeaponLogic
    {
        private WeaponEntityData enemyWeaponEntityData;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            enemyWeaponEntityData = userData as WeaponEntityData;
            if (enemyWeaponEntityData == null)
            {
                Log.Warning("EnemyFighterData is not initialized");
            }
        }


        public override void Attack()
        {
            switch (enemyWeaponEntityData.OwnerEntityId)
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