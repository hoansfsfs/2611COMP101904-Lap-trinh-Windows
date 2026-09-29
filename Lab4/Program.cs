using System;
using System.Collections.Generic;

namespace Lab4_ProductManager
{
    internal class Program
    {
        static ProductService service = new ProductService();

        static void Main(string[] args)
        {
            service.ProductChanged += message =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            };

            while (true)
            {
                Console.WriteLine("\n===== PRODUCT MANAGER =====");
                Console.WriteLine("1. Them san pham");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim theo ma");
                Console.WriteLine("4. Tim theo ten");
                Console.WriteLine("5. Loc theo khoang gia");
                Console.WriteLine("6. Xoa san pham");
                Console.WriteLine("7. Tinh tong gia tri kho");
                Console.WriteLine("0. Thoat");

                Console.Write("Chon: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddProduct();
                            break;

                        case "2":
                            ShowAll();
                            break;

                        case "3":
                            SearchById();
                            break;

                        case "4":
                            SearchByName();
                            break;

                        case "5":
                            FilterByPrice();
                            break;

                        case "6":
                            DeleteProduct();
                            break;

                        case "7":
                            Console.WriteLine(
                                $"Tong gia tri kho: {service.GetTotalInventoryValue():N0}");
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Loi: " + ex.Message);
                    Console.ResetColor();
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Ma SP: ");
            string ma = Console.ReadLine();

            Console.Write("Ten SP: ");
            string ten = Console.ReadLine();

            Console.Write("Don gia: ");
            double gia = double.Parse(Console.ReadLine());

            Console.Write("So luong: ");
            int sl = int.Parse(Console.ReadLine());

            Product product = new Product(ma, ten, gia, sl);

            service.AddProduct(product);
        }

        static void ShowAll()
        {
            List<Product> ds = service.GetAll();

            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            foreach (var item in ds)
            {
                Console.WriteLine(item);
            }
        }

        static void SearchById()
        {
            Console.Write("Nhap ma can tim: ");
            string ma = Console.ReadLine();

            Product p = service.SearchById(ma);

            if (p == null)
                Console.WriteLine("Khong tim thay!");
            else
                Console.WriteLine(p);
        }

        static void SearchByName()
        {
            Console.Write("Nhap tu khoa: ");
            string keyword = Console.ReadLine();

            var result = service.SearchByName(keyword);

            if (result.Count == 0)
                Console.WriteLine("Khong tim thay!");
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void FilterByPrice()
        {
            Console.Write("Gia min: ");
            double min = double.Parse(Console.ReadLine());

            Console.Write("Gia max: ");
            double max = double.Parse(Console.ReadLine());

            var result = service.Filter(
                p => p.Price >= min && p.Price <= max);

            if (result.Count == 0)
            {
                Console.WriteLine("Khong co san pham phu hop!");
                return;
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void DeleteProduct()
        {
            Console.Write("Nhap ma can xoa: ");
            string ma = Console.ReadLine();

            service.RemoveProduct(ma);
        }
    }
}
