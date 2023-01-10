using System.Collections.Generic;

namespace DanPie.Framework.Pause
{
    public interface IPausableObjectsProvider
    {
        IEnumerable<IPausable> GetPausableObjects();
    }
}