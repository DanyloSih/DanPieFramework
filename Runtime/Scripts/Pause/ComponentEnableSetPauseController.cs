using UnityEngine;

namespace DanPie.Framework.Pause
{

    public class ComponentEnableSetPauseController : MonoBehaviour, IPausable
    {
        [SerializeField] private Behaviour _component;
        [SerializeField] private bool _invert;

        public void Pause()
        {
            _component.enabled = _invert;
        }

        public void Resume()
        {
            _component.enabled = !_invert;
        }
    }
}
