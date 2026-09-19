using System;

namespace QuanLyNhanVien
{
    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;

        public int SoNgayLamViec
        {
            get { return soNgayLamViec; }
            set
            {
                if (value >= 0 && value <= 31)
                    soNgayLamViec = value;
                else
                    throw new Exception("Số ngày làm việc phải từ 0 đến 31");
            }
        }

        public NhanVienVanPhong(
            string maNV,
            string hoTen,
            double luongCoBan,
            int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * 200000;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine("=== NHÂN VIÊN VĂN PHÒNG ===");
            base.HienThiThongTin();
            Console.WriteLine($"Số ngày làm việc: {SoNgayLamViec}");
            Console.WriteLine($"Lương thực nhận: {TinhLuong():N0}");
        }
    }
}
