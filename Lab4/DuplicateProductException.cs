using System;

namespace Lab4_ProductManager
{
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException(string message)
            : base(message)
        {
        }
    }
}
