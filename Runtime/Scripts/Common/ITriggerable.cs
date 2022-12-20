using UnityEngine.Events;

namespace DanPie.Framework.Common
{
    public interface ITriggerable
    {
        public UnityEvent Triggered { get; }

        public void Trigger();
    }
}
