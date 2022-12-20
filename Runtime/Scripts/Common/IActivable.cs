using UnityEngine.Events;

namespace DanPie.Framework.Common
{
    public interface IActivable
    {
        bool IsActive { get; }

        public UnityEvent Activated { get; }
        public UnityEvent Deactivated { get; }

        void Activate();
        void Deactivate();
    }
}