using System;

namespace DanPie.Framework.Extensions
{
    public static class FloatExtensions
    {
        public static float Interpolate(this float value, float minValue, float maxValue)
        {
            return Math.Clamp((value - minValue) / (maxValue - minValue), 0, 1);
        }
    }
}