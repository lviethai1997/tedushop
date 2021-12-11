using System;

namespace TeduShop.Common.Exceptions
{
    public class NameDuplicateException : Exception
    {
        public NameDuplicateException()
        {
        }

        public NameDuplicateException(string message) : base(message)
        {
        }

        public NameDuplicateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}