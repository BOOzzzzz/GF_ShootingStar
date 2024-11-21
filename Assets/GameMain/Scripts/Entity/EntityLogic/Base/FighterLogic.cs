using System;
using GameFramework;
using UnityEngine;

namespace ShootingStar
{
    public abstract class FighterLogic : EntityBaseLogic
    {
        public FighterEntityData fighterEntityData;

        protected WeaponLogic weapon;
        protected WaitForSeconds fireInterval;
        protected readonly float angelRotate = 25;

        public Action<bool> updateHealthBar;
        public Action<bool> updateEnergyBar;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            fireInterval = new WaitForSeconds(fighterEntityData.weaponEntityData.AttackInterval);
        }

        public virtual void TakeDamage(int damage)
        {
            fighterEntityData.Health -= damage;
            updateHealthBar?.Invoke(false);
            if (fighterEntityData.Health <= 0)
            {
                OnDead();
            }
        }

        protected virtual void OnDead()
        {
            GameEntry.Entity.HideEntity(this);
            ReferencePool.Release(fighterEntityData);
        }
    }
}