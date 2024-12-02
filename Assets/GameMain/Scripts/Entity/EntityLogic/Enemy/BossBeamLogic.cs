using UnityEngine;

namespace ShootingStar
{
    public class BossBeamLogic:MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerFighterLogic playerFighterLogic))
            {
                playerFighterLogic.TakeDamage((int)playerFighterLogic.fighterEntityData.MaxHealth);

                GameEntry.Entity.ShowEntity<VFXLogic>(VFXEntityData.Create(EnumEntity.VFXEnemyProjectileHit,
                    other.GetContact(0).point,
                    Quaternion.LookRotation(other.GetContact(0).normal))
                );
            }
        }
    }
}