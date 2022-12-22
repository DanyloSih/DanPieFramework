using System;
using DanPie.Framework.Common;
using UnityEngine.Events;

namespace DanPie.Framework.Parameters
{
    public abstract class ActivableParameter : Parameter, IActivable
    {
        private ActivableObject _activableObject = new ActivableObject();

        protected ActivableParameter()
        {
            Activated.AddListener(OnActivated);
            Deactivated.AddListener(OnDeactivated);
        }

        public bool IsActive { get => _activableObject.IsActive; }
        public UnityEvent Activated { get => _activableObject.Activated; }
        public UnityEvent Deactivated { get => _activableObject.Deactivated; }

        public void Activate() => _activableObject.Activate();

        public void Deactivate() => _activableObject.Deactivate();

        protected abstract void OnDeactivated();

        protected abstract void OnActivated();
    }
}
