using System;
using Random = UnityEngine.Random;

namespace ShootingStar
{
    public static class EnumExtension
    {
        public static T RandomRange<T>(T min, T max) where T : struct 
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            int intMin = Convert.ToInt32(min);
            int intMax = Convert.ToInt32(max);
            return (T)Enum.ToObject(typeof(T), Random.Range(intMin, intMax + 1));
        }
    }
}