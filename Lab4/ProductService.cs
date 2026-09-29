using System;
using System.Collections.Generic;

namespace Lab4_ProductManager
{
    public class ProductService
    {
        private Repository<Product> repository;

        public event Action<string> ProductChanged;

        public ProductService()
        {
            repository = new Repository<Product>();
        }

        public void AddProduct(Product product)
        {
            if (repository.FindById(product.MaSP) != null)
            {
                throw new DuplicateProductException(
                    $"San pham co ma {product.MaSP} da ton tai!");
            }

            repository.Add(product);

            ProductChanged?.Invoke(
                $"Them san pham {product.MaSP} thanh cong!");
        }

        public void RemoveProduct(string maSP)
        {
            Product product = repository.FindById(maSP);

            if (product == null)
            {
                throw new ProductNotFoundException(
                    $"Khong tim thay san pham {maSP}");
            }

            repository.Remove(product);

            ProductChanged?.Invoke(
                $"Xoa san pham {maSP} thanh cong!");
        }

        public Product SearchById(string maSP)
        {
            return repository.FindById(maSP);
        }

        public List<Product> SearchByName(string keyword)
        {
            return repository.Find(p =>
                p.TenSP.Contains(keyword,
                StringComparison.OrdinalIgnoreCase));
        }

        public List<Product> Filter(Func<Product, bool> condition)
        {
            return repository.Find(condition);
        }

        public List<Product> GetAll()
        {
            return repository.GetAll();
        }

        public double GetTotalInventoryValue()
        {
            double total = 0;

            foreach (var item in repository.GetAll())
            {
                total += item.Price * item.Quantity;
            }

            return total;
        }
    }
}
