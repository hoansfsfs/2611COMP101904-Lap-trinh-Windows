using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanVien
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> danhSach = new List<NhanVien>();

            danhSach.Add(new NhanVienVanPhong(
                "VP01", "Nguyen Van A", 8000000, 25));

            danhSach.Add(new NhanVienVanPhong(
                "VP02", "Tran Thi B", 7000000, 22));

            danhSach.Add(new NhanVienKinhDoanh(
                "KD01", "Le Van C", 6000000, 100000000));

            danhSach.Add(new NhanVienKinhDoanh(
                "KD02", "Pham Thi D", 6500000, 80000000));

            danhSach.Add(new NhanVienVanPhong(
                "VP03", "Hoang Van E", 9000000, 28));

            // Bonus
            danhSach.Add(new NhanVienThoiVu(
                "TV01", "Do Van F", 120, 70000));

            int chon;

            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuất danh sách nhân viên");
                Console.WriteLine("2. Tìm nhân viên theo mã");
                Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
                Console.WriteLine("4. Tính tổng lương công ty phải trả");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");

                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        Console.WriteLine("\nDANH SÁCH NHÂN VIÊN");
                        foreach (NhanVien nv in danhSach)
                        {
                            nv.HienThiThongTin();
                            Console.WriteLine("-------------------");
                        }
                        break;

                    case 2:
                        Console.Write("Nhập mã cần tìm: ");
                        string ma = Console.ReadLine();

                        NhanVien timThay =
                            danhSach.Find(nv => nv.MaNhanVien.Equals(ma,
                            StringComparison.OrdinalIgnoreCase));

                        if (timThay != null)
                            timThay.HienThiThongTin();
                        else
                            Console.WriteLine("Không tìm thấy!");
                        break;

                    case 3:
                        NhanVien maxLuong =
                            danhSach.OrderByDescending(
                                nv => nv.TinhLuong()).First();

                        Console.WriteLine("\nNhân viên có lương cao nhất:");
                        maxLuong.HienThiThongTin();
                        break;

                    case 4:
                        double tongLuong =
                            danhSach.Sum(nv => nv.TinhLuong());

                        Console.WriteLine(
                            $"Tổng lương công ty phải trả: {tongLuong:N0}");
                        break;

                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

            } while (chon != 0);
        }
    }
}
