using UnityEngine;
using UnityEngine.Events;

namespace DanPie.Framework.Common
{
    public class ActivableObject : IActivable
    {
        public bool IsActive { get; private set; } = false;
        public UnityEvent Activated { get; } = new UnityEvent();
        public UnityEvent Deactivated { get; } = new UnityEvent();

        public void Activate()
        {
            if (IsActive == false)
            {
                IsActive = true;
                OnActivate();
                Activated.Invoke();
            }
        }

        public void Deactivate()
        {
            if (IsActive == true)
            {
                IsActive = false;
                OnDeactivate();
                Deactivated.Invoke();
            }

        }

        protected virtual void OnActivate() { }
        protected virtual void OnDeactivate() { }
    }
}
