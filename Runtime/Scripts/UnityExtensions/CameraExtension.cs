using System;
using UnityEngine;

namespace DanPie.Framework.UnityExtensions
{
    public static class CameraExtension
    {
        public static float GetRadiusOfSphereFittedInCamera(this Camera camera)
        {
            float radAngle = camera.fieldOfView * Mathf.Deg2Rad;
            float radHFOV = (float)(2 * Math.Atan(Mathf.Tan(radAngle / 2) * camera.aspect));
            float hFOV = Mathf.Rad2Deg * radHFOV;
            float horizontalFOVRadius = CalculateRadius(camera.farClipPlane, hFOV);
            float verticalFOVRadius = CalculateRadius(camera.farClipPlane, camera.fieldOfView);
            float r = Mathf.Min(horizontalFOVRadius, verticalFOVRadius);
            return r;
        }

        private static float CalculateRadius(float farClipPlane, float angle)
        {
            float g = farClipPlane / (Mathf.Cos(angle / 2f / Mathf.Rad2Deg));
            float k = (Mathf.Tan(angle / 2f / Mathf.Rad2Deg)) * farClipPlane * 2;
            float p = (g * 2 + k) / 2f;
            float s = Mathf.Sqrt(p * (p - g) * (p - g) * (p - k));
            return s / p;
        }
    }
}
