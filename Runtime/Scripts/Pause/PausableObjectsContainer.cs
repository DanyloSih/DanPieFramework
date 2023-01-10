using System.Collections.Generic;
using System.Linq;

namespace DanPie.Framework.Pause
{
    public class PausableObjectsContainer : IPausableObjectsProvider
    {
        private List<IPausable> _objects = new List<IPausable>();

        public IEnumerable<IPausable> GetPausableObjects()
        {
            _objects = _objects.Where((x) => x != null).ToList();
            return _objects;
        }

        public void AddIfNotInList(IPausable pausable)
        {
            if (!_objects.Contains(pausable))
            {
                _objects.Add(pausable);
            }
        }

        public void RemoveIfInList(IPausable pausable)
        {
            if (_objects.Contains(pausable))
            {
                _objects.Remove(pausable);
            }
        }
    }
}
