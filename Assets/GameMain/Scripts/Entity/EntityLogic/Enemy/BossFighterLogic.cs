using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class BossFighterLogic:EnemyFighterLogic
    {
        public override void ShowEntity()
        {
            GameEntry.Entity.ShowEntity<ThrusterLogic>(fighterEntityData.thrusterEntityData);
            GameEntry.Entity.ShowEntity<BossWeaponLogic>(fighterEntityData.weaponEntityData);
            GameEntry.Entity.ShowEntity<HealthBarLogic>(fighterEntityData.healthBarEntityData);
            GameEntry.Entity.ShowEntity<MuzzleVFXLogic>(fighterEntityData.vfxAccessoryEntityData);
        }
        
        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            if (childEntity is BossWeaponLogic enemyWeaponLogic)
            {
                weaponLogic = enemyWeaponLogic;
            }
            
            if (childEntity is MuzzleVFXLogic enemyMuzzleVFXLogic)
            {
                muzzleVFXLogic = enemyMuzzleVFXLogic;
            }
        }
    }
}