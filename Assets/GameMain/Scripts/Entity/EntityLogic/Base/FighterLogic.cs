using UnityEngine;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class FighterLogic : EntityBaseLogic
    {
        [SerializeField] protected FighterEntityData fighterEntityData;

        protected WeaponLogic weapon;
        protected WaitForSeconds fireInterval;
        protected float angelRotate = 25;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            fireInterval = new WaitForSeconds(fighterEntityData.weaponEntityData.AttackInterval);
        }

        public virtual void TakeDamage(int damage)
        {
            fighterEntityData.Health -= damage;
            if (fighterEntityData.Health <= 0)
            {
                OnDead();
            }
        }

        protected virtual void OnDead()
        {
            GameEntry.Entity.HideEntity(fighterEntityData.Id);
        }
    }
}