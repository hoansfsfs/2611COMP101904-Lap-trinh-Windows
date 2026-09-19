using System;

namespace QuanLyNhanVien
{
    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;

        public double DoanhSo
        {
            get { return doanhSo; }
            set
            {
                if (value >= 0)
                    doanhSo = value;
                else
                    throw new Exception("Doanh số phải >= 0");
            }
        }

        public NhanVienKinhDoanh(
            string maNV,
            string hoTen,
            double luongCoBan,
            double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + DoanhSo * 0.05;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine("=== NHÂN VIÊN KINH DOANH ===");
            base.HienThiThongTin();
            Console.WriteLine($"Doanh số: {DoanhSo:N0}");
            Console.WriteLine($"Lương thực nhận: {TinhLuong():N0}");
        }
    }
}
