using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DanPie.Framework.Pause
{
    public class PausableObjectsProvider : IPausableObjectsProvider
    {
        public List<IPausable> GetPausableObjects()
            => MonoBehaviour.FindObjectsOfType<MonoBehaviour>().OfType<IPausable>().ToList();
    }
}
