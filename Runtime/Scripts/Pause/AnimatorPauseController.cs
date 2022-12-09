using UnityEngine;

namespace DanPie.Framework.Pause
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorPauseController : MonoBehaviour, IPausable
    {
        private Animator _animator;
        private bool _enabled;

        protected void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Pause()
        {
            _enabled = _animator.enabled;
            _animator.enabled = false;
        }

        public void Resume()
        {
            _animator.enabled = _animator;
        }
    }
}
