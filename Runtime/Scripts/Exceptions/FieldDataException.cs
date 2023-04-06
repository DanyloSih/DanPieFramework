using System;

namespace DanPie.Framework.Exceptions
{
    public class FieldDataException : Exception
    {
        public FieldDataException(string fieldClassName, string fieldName, string message) 
            : base($"There is a problem with the data in field \"{fieldName}\" of class \"{fieldClassName}\"!"
                  + message)
        {
        }
    }
}
