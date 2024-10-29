using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class WeaponLogic : EntityBaseLogic
    {
        [SerializeField]private WeaponEntityData weaponData;

        private Transform middleMuzzle;
        private Transform topMuzzle;
        private Transform bottomMuzzle;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            weaponData = userData as WeaponEntityData;
            if (weaponData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }

            GameEntry.Entity.AttachEntity(Entity, weaponData.OwnerId, "Weapon");
            InitData(weaponData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            middleMuzzle = transform.Find("middleMuzzle").transform;
            topMuzzle = transform.Find("topMuzzle").transform;
            bottomMuzzle = transform.Find("bottomMuzzle").transform;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            weaponData.Position = CachedTransform.position;
            weaponData.Rotation = CachedTransform.rotation;
        }

        public void Attack()
        {
            switch (weaponData.WeaponPower)
            {
                case 1:
                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile1 ,  middleMuzzle.position));
                    break;
                case 2:
                    
                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile1 ,  middleMuzzle.position));
                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile1 ,  topMuzzle.position));
                    break;
                case 3:

                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile1 ,  middleMuzzle.position));

                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile2,topMuzzle.position));

                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile3,bottomMuzzle.position));
                    break;
            }
        }
    }
}