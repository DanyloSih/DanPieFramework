using DanPie.Framework.Common;
using UnityEngine.Events;

namespace DanPie.Framework.Parameters
{
    public abstract class ActivableParameter : Parameter, IActivable
    {
        private ActivableObject _activableObject = new ActivableObject();

        public bool IsActive { get => _activableObject.IsActive; }
        public UnityEvent Activated { get => _activableObject.Activated; }
        public UnityEvent Deactivated { get => _activableObject.Deactivated; }

        public void Activate() => _activableObject.Activate();

        public void Deactivate() => _activableObject.Deactivate();
    }
}
