using UnityEngine;

namespace ShootingStar
{
    public class HealthBarEntityData:EntityBaseData
    {
        public Transform follow;

        public Transform Follow
        {
            get => follow;
            set => follow = value;
        }
    }
}