using UnityEngine;

namespace DanPie.Framework.Pause
{
    public class ComponentEnableTogglePauseController : MonoBehaviour, IPausable
    {
        [SerializeField] private Behaviour _component;

        private bool _onPausedValue = false;

        public void Pause()
        {
            _onPausedValue = _component.enabled;
            _component.enabled = !_onPausedValue;
        }

        public void Resume()
        {
            _component.enabled = _onPausedValue;
        }
    }
}
