using System;

namespace DanPie.Framework.Common
{
    public class NonInitializedException : Exception
    {
        public NonInitializedException() 
            : base("An object must be initialized at least once before being used!")
        {
        }

        public NonInitializedException(string message) : base(message)
        {
        }
    }
}