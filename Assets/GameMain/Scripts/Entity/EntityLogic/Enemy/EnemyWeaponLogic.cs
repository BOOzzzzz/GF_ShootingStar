using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class EnemyWeaponLogic:WeaponLogic
    {
        private WeaponEntityData enemyWeaponEntityData;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            base.OnInit(userData);

            enemyWeaponEntityData = userData as WeaponEntityData;
            if (enemyWeaponEntityData == null)
            {
                Log.Warning("EnemyFighterData is not initialized");
            }
        }
        

        public override void Attack()
        {
            switch (enemyWeaponEntityData.entityData.ID)
            {
                case 3001:
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(BulletEntityData.Create(EnumEntity.EnemyProjectileBasic ,  CachedTransform.position));
                    break;
                case 3002:
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(BulletEntityData.Create(EnumEntity.EnemyProjectileAiming ,  CachedTransform.position));
                    break;
                case 3003:
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(BulletEntityData.Create(EnumEntity.EnemyProjectile10Oclock ,  CachedTransform.position));
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(BulletEntityData.Create(EnumEntity.EnemyProjectile8Oclock ,  CachedTransform.position));
                    GameEntry.Entity.ShowEntity<EnemyBulletLogic>(BulletEntityData.Create(EnumEntity.EnemyProjectile9Oclock ,  CachedTransform.position));
                    break;
            }
        }
    }
}