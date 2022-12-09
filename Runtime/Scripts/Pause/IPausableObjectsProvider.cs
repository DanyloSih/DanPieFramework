using System.Collections.Generic;

namespace DanPie.Framework.Pause
{
    public interface IPausableObjectsProvider
    {
        List<IPausable> GetPausableObjects();
    }
}