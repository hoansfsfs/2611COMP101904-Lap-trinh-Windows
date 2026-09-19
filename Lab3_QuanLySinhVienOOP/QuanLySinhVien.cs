using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSachSinhVien;

        public QuanLySinhVien()
        {
            danhSachSinhVien = new List<SinhVien>();
        }

        public bool Them(SinhVien sv)
        {
            bool tonTai = danhSachSinhVien.Any(x =>
                x.MaSinhVien.Equals(
                    sv.MaSinhVien,
                    StringComparison.OrdinalIgnoreCase));

            if (tonTai)
                return false;

            danhSachSinhVien.Add(sv);
            return true;
        }

        public List<SinhVien> LayDanhSach()
        {
            return danhSachSinhVien;
        }

        public SinhVien TimTheoMa(string maSV)
        {
            return danhSachSinhVien.FirstOrDefault(x =>
                x.MaSinhVien.Equals(
                    maSV,
                    StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return danhSachSinhVien
                .Where(x =>
                    x.HoTen.ToLower()
                    .Contains(tuKhoa.ToLower()))
                .ToList();
        }

        public bool Sua(string maSV, double diemMoi)
        {
            SinhVien sv = TimTheoMa(maSV);

            if (sv == null)
                return false;

            sv.DiemTrungBinh = diemMoi;

            return true;
        }

        public bool Xoa(string maSV)
        {
            SinhVien sv = TimTheoMa(maSV);

            if (sv == null)
                return false;

            danhSachSinhVien.Remove(sv);

            return true;
        }

        public List<SinhVien> SapXepTheoDiem()
        {
            return danhSachSinhVien
                .OrderByDescending(x => x.DiemTrungBinh)
                .ToList();
        }

        public List<SinhVien> LocSinhVienDat()
        {
            return danhSachSinhVien
                .Where(x => x.DiemTrungBinh >= 5)
                .ToList();
        }
    }
}
