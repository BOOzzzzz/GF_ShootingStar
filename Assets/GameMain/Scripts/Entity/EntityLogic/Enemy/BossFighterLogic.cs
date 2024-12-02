using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public class BossFighterLogic:EnemyFighterLogic
    {
        private WaitUntil waitAttackFinished;
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
                waitAttackFinished = new WaitUntil(weaponLogic.AttackFinished);
            }
            
            if (childEntity is MuzzleVFXLogic enemyMuzzleVFXLogic)
            {
                muzzleVFXLogic = enemyMuzzleVFXLogic;
            }
        }

        protected override IEnumerator RandomFire()
        {
            while (!isPlayerDead)
            {
                yield return weaponFireInterval;
                muzzleVFXLogic.muzzleParticleSystem.Play();
                weaponLogic.Attack();
                yield return waitAttackFinished;
            }
        }
    }
}