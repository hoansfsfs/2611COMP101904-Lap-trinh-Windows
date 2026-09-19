using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab3_QuanLySinhVienOOP
{
    internal class Program
    {
        static QuanLySinhVien qlsv = new QuanLySinhVien();

        static void Main(string[] args)
        {
            int luaChon;

            do
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4. Tim sinh vien theo ten");
                Console.WriteLine("5. Sua diem trung binh");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo diem giam dan");
                Console.WriteLine("8. Loc sinh vien dat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                int.TryParse(Console.ReadLine(), out luaChon);

                switch (luaChon)
                {
                    case 1:
                        ThemSinhVien();
                        break;

                    case 2:
                        XuatDanhSach(qlsv.LayDanhSach());
                        break;

                    case 3:
                        TimTheoMa();
                        break;

                    case 4:
                        TimTheoTen();
                        break;

                    case 5:
                        SuaDiem();
                        break;

                    case 6:
                        XoaSinhVien();
                        break;

                    case 7:
                        XuatDanhSach(qlsv.SapXepTheoDiem());
                        break;

                    case 8:
                        XuatDanhSach(qlsv.LocSinhVienDat());
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (luaChon != 0);
        }

        static void ThemSinhVien()
        {
            try
            {
                Console.Write("Ma sinh vien: ");
                string maSV = Console.ReadLine();

                Console.Write("Ho ten: ");
                string hoTen = Console.ReadLine();

                DateTime ngaySinh;

                while (true)
                {
                    Console.Write("Ngay sinh (dd/MM/yyyy): ");

                    bool hopLe = DateTime.TryParseExact(
                        Console.ReadLine(),
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out ngaySinh);

                    if (hopLe)
                        break;

                    Console.WriteLine("Ngay sinh khong hop le!");
                }

                Console.Write("Ma lop: ");
                string maLop = Console.ReadLine();

                double diemTB;

                while (true)
                {
                    Console.Write("Diem trung binh: ");

                    if (double.TryParse(Console.ReadLine(), out diemTB)
                        && diemTB >= 0
                        && diemTB <= 10)
                    {
                        break;
                    }

                    Console.WriteLine("Diem phai tu 0 den 10!");
                }

                SinhVien sv = new SinhVien(
                    maSV,
                    hoTen,
                    ngaySinh,
                    maLop,
                    diemTB);

                if (qlsv.Them(sv))
                    Console.WriteLine("Them sinh vien thanh cong!");
                else
                    Console.WriteLine("Ma sinh vien da ton tai!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void XuatDanhSach(List<SinhVien> danhSach)
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            foreach (SinhVien sv in danhSach)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        static void TimTheoMa()
        {
            Console.Write("Nhap ma sinh vien: ");
            string maSV = Console.ReadLine();

            SinhVien sv = qlsv.TimTheoMa(maSV);

            if (sv == null)
                Console.WriteLine("Khong tim thay!");
            else
                Console.WriteLine(sv.LayThongTin());
        }

        static void TimTheoTen()
        {
            Console.Write("Nhap tu khoa ten: ");
            string tuKhoa = Console.ReadLine();

            List<SinhVien> ketQua =
                qlsv.TimTheoTen(tuKhoa);

            XuatDanhSach(ketQua);
        }

        static void SuaDiem()
        {
            Console.Write("Nhap ma sinh vien: ");
            string maSV = Console.ReadLine();

            double diemMoi;

            while (true)
            {
                Console.Write("Nhap diem moi: ");

                if (double.TryParse(Console.ReadLine(), out diemMoi)
                    && diemMoi >= 0
                    && diemMoi <= 10)
                {
                    break;
                }

                Console.WriteLine("Diem khong hop le!");
            }

            if (qlsv.Sua(maSV, diemMoi))
                Console.WriteLine("Cap nhat thanh cong!");
            else
                Console.WriteLine("Khong tim thay sinh vien!");
        }

        static void XoaSinhVien()
        {
            Console.Write("Nhap ma sinh vien can xoa: ");
            string maSV = Console.ReadLine();

            if (qlsv.Xoa(maSV))
                Console.WriteLine("Xoa thanh cong!");
            else
                Console.WriteLine("Khong tim thay sinh vien!");
        }
    }
}
