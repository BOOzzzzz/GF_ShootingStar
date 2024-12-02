using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootingStar
{
    public class BossWeaponLogic : WeaponLogic
    {
        private float timer;
        private Transform mostTopMuzzle;
        private Transform mostBottomMuzzle;
        private Animator animator;
        private static readonly int LaunchBeam = Animator.StringToHash("launchBeam");
        private WaitForSeconds fireInterval = new (0.2f);
        private WaitForSeconds beamDelayInterval = new (7f);

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            mostTopMuzzle = transform.Find("mostTopMuzzle").transform;
            mostBottomMuzzle = transform.Find("mostBottomMuzzle").transform;

            animator = GetComponentInParent<Animator>();
        }

        public override void Attack()
        {
            int randomAttack = Random.Range(0, 3);
            isAttackFinished = false;

            switch (randomAttack)
            {
                case 0:
                    StartCoroutine(ContinueFire(() =>
                    {
                        GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                            BulletEntityData.Create(EnumEntity.EnemyProjectile, middleMuzzle.position));
                    }));
                    break;
                case 1:
                    StartCoroutine(ContinueFire(() =>
                    {
                        GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                            BulletEntityData.Create(EnumEntity.EnemyProjectile, middleMuzzle.position,
                                middleMuzzle.rotation));
                        GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                            BulletEntityData.Create(EnumEntity.EnemyProjectile, bottomMuzzle.position,
                                bottomMuzzle.rotation));
                        GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                            BulletEntityData.Create(EnumEntity.EnemyProjectile, topMuzzle.position,
                                topMuzzle.rotation));
                        GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                            BulletEntityData.Create(EnumEntity.EnemyProjectile, mostBottomMuzzle.position,
                                mostBottomMuzzle.rotation));
                        GameEntry.Entity.ShowEntity<EnemyBulletLogic>(
                            BulletEntityData.Create(EnumEntity.EnemyProjectile, mostTopMuzzle.position,
                                mostTopMuzzle.rotation));
                    }));
                    break;
                case 2:
                    animator.SetTrigger(LaunchBeam);
                    StartCoroutine(LaunchBeamDelay());
                    break;
            }
        }

        private IEnumerator LaunchBeamDelay()
        {
            yield return beamDelayInterval;
            isAttackFinished = true;  
        }

        private IEnumerator ContinueFire(Action attack)
        {
            timer = 0;
            while (timer < 3)
            {
                timer += 0.2f;
                attack?.Invoke();
                yield return fireInterval;
            }
            isAttackFinished = true;
        }
    }
}