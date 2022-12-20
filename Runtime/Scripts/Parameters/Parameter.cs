
using DanPie.Framework.Common;

namespace DanPie.Framework.Parameters
{
    public abstract class Parameter : INameAdapter
    {
        public abstract string Name { get; set; }
    }
}
