using System;

namespace Lab4_ProductManager
{
    public class Product : IEntity
    {
        private double price;
        private int quantity;

        public string MaSP { get; set; }
        public string TenSP { get; set; }

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Don gia khong duoc am!");
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("So luong khong duoc am!");
                quantity = value;
            }
        }

        public string Id => MaSP;

        public Product(string maSP, string tenSP, double price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Ma san pham khong duoc rong!");

            MaSP = maSP;
            TenSP = tenSP;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"MaSP: {MaSP}, TenSP: {TenSP}, DonGia: {Price:N0}, SoLuong: {Quantity}";
        }
    }
}
