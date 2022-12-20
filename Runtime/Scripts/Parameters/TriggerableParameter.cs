using DanPie.Framework.Common;
using UnityEngine.Events;

namespace DanPie.Framework.Parameters
{
    /// <summary>
    /// Designed to be used as a type in UIParameterControllerFactory
    /// </summary>
    public abstract class TriggerableParameter : Parameter, ITriggerable
    {
        private bool _isTriggered = false;

        public UnityEvent Triggered { get; } = new UnityEvent();

        public void Trigger()
        {
            if (_isTriggered == false)
            {
                _isTriggered = true;
                OnTrigger();
                Triggered.Invoke();
                _isTriggered = false;
            }
        }

        protected abstract void OnTrigger();
    }
}
