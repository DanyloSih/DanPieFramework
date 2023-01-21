using System;
using DanPie.Framework.UnityExtensions;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace DanPie.Framework.Common
{
    public class TransformOffsetTranslator : MonoBehaviour
    {
        [Serializable]
        public class GizmoSettings
        {
            public float Scale = 1;
        }

        [SerializeField] private Vector3 _rootOffset;
        [SerializeField] private Vector3 _rotationOffset;
        [SerializeField] private GizmoSettings _gizmoSettings;

        public event Action TransformChanged;

        protected Vector3 RootPositionOffset { get => _rootOffset; }

        public Vector3 GetRootPosition() => transform.ToGlobal(_rootOffset);

        public void SetPose(Vector3 position, Vector3 direction) 
            => SetPose(position, direction, Vector3.one, Vector3.up);

        public void SetPose(Vector3 position, Vector3 direction, Vector3 localScale, Vector3 up)
        {
            LookInDirection(direction, up);
            MoveTo(position);
            SetLocalScale(localScale);
            TransformChanged?.Invoke();
        }

        protected virtual void LookInDirection(Vector3 direction, Vector3 up)
        {
            transform.LookAt(transform.position + direction, up);
            transform.Rotate(_rotationOffset);
        }

        protected virtual void MoveTo(Vector3 position)
        {
            Vector3 scaledOffset = _rootOffset;
            scaledOffset.Scale(transform.lossyScale);
            transform.position = position - transform.rotation * scaledOffset;
        }

        protected virtual void SetLocalScale(Vector3 scale)
        {
            Vector3 realPos = transform.ToGlobal(_rootOffset);
            transform.localScale = scale;
            MoveTo(realPos);
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.ToGlobal(_rootOffset), 0.2f * _gizmoSettings.Scale);

            Gizmos.color = Color.green;
            Vector3 newDirection = Quaternion.Euler(_rotationOffset) * transform.forward;
            Gizmos.DrawLine(
                GetRootPosition(),
                GetRootPosition() + newDirection.normalized * _gizmoSettings.Scale);
        }
#endif
    }
}
