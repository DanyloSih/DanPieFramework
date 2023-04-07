using UnityEngine;

namespace DanPie.Framework.Extensions
{
    public static class SystemRandomExtension
    {
        /// <summary>
        /// Min value - inclusive, Max value - inclusive
        /// </summary>
        public static float NextFloat(this System.Random rand, float a, float b)
        {
            float realMin = Mathf.Min(a, b);
            float realMax = Mathf.Max(a, b);

            return (float)(rand.NextDouble() * (realMax - realMin) + realMin);
        }

        /// <summary>
        /// Generates a random number from the smallest float value to the largest float.
        /// </summary>
        public static float NextFloat(this System.Random rand)
        {
            return rand.NextFloat(float.MinValue, float.MaxValue);
        }
        
        /// <summary>
        /// Min value - inclusive, Max value - inclusive
        /// </summary>
        public static float NextFloat(this System.Random rand, Vector2 vector)
        {
            return rand.NextFloat(vector.x, vector.y);
        }

        /// <summary>
        /// Min value - inclusive, Max value - inclusive
        /// </summary>
        public static float NextFloat(this System.Random rand, Vector2Int vector)
        {
            return rand.NextFloat(vector.x, vector.y);
        }

        /// <summary>
        /// Min value - inclusive, Max value - inclusive
        /// </summary>
        public static int NextInt(this System.Random rand, int a, int b)
        {
            int realMin = Mathf.Min(a, b);
            int realMax = Mathf.Max(a, b) + 1;

            return rand.Next(realMin, realMax);
        }

        /// <summary>
        /// Generates a random number from -2147483648 to 2147483647 inclusive.
        /// </summary>
        public static int NextInt(this System.Random rand)
        {
            return rand.Next(int.MinValue, int.MaxValue);
        }


        /// <summary>
        /// Min value - inclusive, Max value - inclusive
        /// </summary>
        public static int NextInt(this System.Random rand, Vector2 vector)
        {
            return rand.NextInt(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
        }

        /// <summary>
        /// Min value - inclusive, Max value - inclusive
        /// </summary>
        public static int NextInt(this System.Random rand, Vector2Int vector)
        {
            return rand.NextInt(vector.x, vector.y);
        }
    }
}