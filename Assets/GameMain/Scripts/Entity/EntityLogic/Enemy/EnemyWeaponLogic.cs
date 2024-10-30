namespace ShootingStar
{
    public class EnemyWeaponLogic:WeaponLogic
    {
        public override void Attack()
        {
            GameEntry.Entity.ShowEntity<EnemyBulletLogic>(BulletEntityData.Create(EnumEntity.EnemyProjectileBasic ,  CachedTransform.position));
        }
    }
}