using UnityEngine;

namespace DanPie.Framework.Pause
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyPauseController : MonoBehaviour, IPausable
    {
        private Rigidbody _rigidbody;
        private bool _isKinematic = false;
        private Vector3 _velocity;

        public void Pause()
        {
            _isKinematic = _rigidbody.isKinematic;
            _velocity = _rigidbody.velocity;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
        }

        public void Resume()
        {
            _rigidbody.velocity = _velocity;
            _rigidbody.isKinematic = _isKinematic;
        }

        protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
