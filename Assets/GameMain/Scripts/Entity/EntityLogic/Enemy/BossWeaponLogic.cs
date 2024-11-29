using System.Collections;
using UnityEngine;

namespace ShootingStar
{
    public class BossWeaponLogic : WeaponLogic
    {

        private float timer = 0;
        public override void Attack()
        {
            int randomAttack = Random.Range(0, 2);

            switch (randomAttack)
            {
                case 0:
                    StartCoroutine(ContinueFire1());
                    break;
                case 1:
                    StartCoroutine(ContinueFire2());
                    break;
            }
        }

        private IEnumerator ContinueFire1()
        {
            timer = 0;
            while (timer < 3)
            {
                timer += 0.2f;
                GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                    BulletEntityData.Create(EnumEntity.EnemyProjectile, middleMuzzle.position));
                yield return new WaitForSeconds(0.2f);
            }
        }
        
        private IEnumerator ContinueFire2()
        {
            timer = 0;
            while (timer < 3)
            {
                timer += 0.2f;
                GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                    BulletEntityData.Create(EnumEntity.EnemyProjectile, middleMuzzle.position,
                        middleMuzzle.rotation));
                GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                    BulletEntityData.Create(EnumEntity.EnemyProjectile, bottomMuzzle.position,
                        bottomMuzzle.rotation));
                GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                    BulletEntityData.Create(EnumEntity.EnemyProjectile, topMuzzle.position, topMuzzle.rotation));
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}