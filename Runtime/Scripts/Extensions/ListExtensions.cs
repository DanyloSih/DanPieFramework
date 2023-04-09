using System.Collections.Generic;

namespace DanPie.Framework.Extensions
{
    public static class ListExtensions
    {
        public static T PopAt<T>(this List<T> list, int index)
        {
            T r = list[index];
            list.RemoveAt(index);
            return r;
        }
    } 
}