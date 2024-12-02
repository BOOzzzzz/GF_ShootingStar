using System;
using GameFramework;
using UnityEngine;

namespace ShootingStar
{
    public abstract class FighterLogic : EntityBaseLogic
    {
        public FighterEntityData fighterEntityData;

        protected WeaponLogic weaponLogic;
        protected WaitForSeconds weaponFireInterval;
        protected readonly float angelRotate = 25;

        public Action<bool> updateHealthBar;
        public Action<bool> updateEnergyBar;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            weaponFireInterval = new WaitForSeconds(fighterEntityData.weaponEntityData.AttackInterval);
            
            ShowEntity();
        }
        
        public abstract void ShowEntity();

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