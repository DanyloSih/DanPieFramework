using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DanPie.Framework.Pause
{
    public class PausableComponentsFinder : IPausableObjectsProvider
    {
        public IEnumerable<IPausable> GetPausableObjects()
            => MonoBehaviour.FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
    }
}
