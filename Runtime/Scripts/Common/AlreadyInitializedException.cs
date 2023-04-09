using System;

namespace DanPie.Framework.Common
{
    public class AlreadyInitializedException : Exception
    {
        public AlreadyInitializedException()
            : base("The object is already initialized!")
        {
        }

        public AlreadyInitializedException(string message) : base(message)
        {
        }
    }
}