using System.Collections.Generic;

namespace DanPie.Framework.Common
{
    public class Resetter
    {
        private List<IResettable> _resettable = new List<IResettable>();

        public void AddResettableObject(IResettable resettableObject)
        {
            _resettable.Add(resettableObject);
        }

        public void Clear()
        {
            _resettable.Clear();
        }

        public void Reset()
        {
            foreach (IResettable hack in _resettable)
            {
                hack.ResetObject();
            }
        }
    }
}