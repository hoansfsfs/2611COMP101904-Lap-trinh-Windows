using System;

namespace Lab4_ProductManager
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message)
            : base(message)
        {
        }
    }
}
