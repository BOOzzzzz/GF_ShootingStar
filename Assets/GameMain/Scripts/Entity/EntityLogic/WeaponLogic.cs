using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class WeaponLogic : EntityBaseLogic
    {
        [SerializeField]private WeaponEntityData weaponData;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            weaponData = userData as WeaponEntityData;
            if (weaponData == null)
            {
                Log.Warning("ThrusterData is not initialized");
            }

            GameEntry.Entity.AttachEntity(Entity, weaponData.OwnerId, "Weapon");
            //InitData(weaponPointData,true);
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
                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile1 ,  new Vector3(0.95f,-0.05f,0)));
                    break;
                case 2:

                    break;
                case 3:

                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile1 ,  new Vector3(0.95f,-0.05f,0)));

                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile2,new Vector3(0.95f,0.1f,0)));

                    GameEntry.Entity.ShowBullet(BulletEntityData.Create(EnumEntity.PlayerProjectile3,new Vector3(0.95f,-0.2f,0)));
                    break;
            }
        }
    }
}