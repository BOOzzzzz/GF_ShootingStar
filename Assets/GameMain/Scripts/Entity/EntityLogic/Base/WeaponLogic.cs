using System;
using GameFramework;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace ShootingStar
{
    public abstract class WeaponLogic : EntityBaseLogic
    {
        protected WeaponEntityData weaponData;
        
        protected Transform middleMuzzle;
        protected Transform topMuzzle;
        protected Transform bottomMuzzle;
        
        [FormerlySerializedAs("attackFinished")] public bool isAttackFinished;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            weaponData = userData as WeaponEntityData;
            if (weaponData == null)
            {
                Log.Warning("WeaponData is not initialized");
            }
            
            GameEntry.Entity.AttachEntity(Entity, weaponData.OwnerId, "Weapon");
            InitData(weaponData);
            
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

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            ReferencePool.Release(weaponData);
        }

        public bool AttackFinished()
        {
            return isAttackFinished;
        }

        public abstract void Attack();

    }
}