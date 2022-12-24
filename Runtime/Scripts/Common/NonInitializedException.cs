using System;

namespace DanPie.Framework.Common
{
    public class NonInitializedException : Exception
    {
        public NonInitializedException() 
            : base("The object is still not initialized!")
        {
        }

        public NonInitializedException(string message) : base(message)
        {
        }
    }
}