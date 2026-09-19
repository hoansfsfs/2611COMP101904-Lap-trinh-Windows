using System;

namespace Lab3_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        private double diemTrungBinh;

        public string MaSinhVien { get; set; }

        public string MaLop { get; set; }

        public double DiemTrungBinh
        {
            get { return diemTrungBinh; }
            set
            {
                if (value < 0 || value > 10)
                    throw new Exception("Điểm phải từ 0 đến 10.");

                diemTrungBinh = value;
            }
        }

        public SinhVien()
        {
        }

        public SinhVien(
            string maSinhVien,
            string hoTen,
            DateTime ngaySinh,
            string maLop,
            double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8)
                return "Giỏi";

            if (DiemTrungBinh >= 6.5)
                return "Khá";

            if (DiemTrungBinh >= 5)
                return "Đạt";

            return "Không đạt";
        }

        public override string LayThongTin()
        {
            return $"Mã SV: {MaSinhVien} | " +
                   $"Họ tên: {HoTen} | " +
                   $"Ngày sinh: {NgaySinh:dd/MM/yyyy} | " +
                   $"Mã lớp: {MaLop} | " +
                   $"Điểm TB: {DiemTrungBinh:F1} | " +
                   $"Xếp loại: {XepLoai()}";
        }
    }
}
