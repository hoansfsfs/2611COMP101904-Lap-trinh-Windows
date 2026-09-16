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

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int n;

            do
            {
                Console.Write("Nhập số lượng nhân viên (ít nhất 5): ");
                n = int.Parse(Console.ReadLine());
            } while (n < 5);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhân viên thứ {i + 1}");

                Console.WriteLine("1. Văn phòng");
                Console.WriteLine("2. Kinh doanh");
                Console.WriteLine("3. Thời vụ");

                Console.Write("Chọn loại: ");
                int loai = int.Parse(Console.ReadLine());

                Console.Write("Mã NV: ");
                string ma = Console.ReadLine();

                Console.Write("Họ tên: ");
                string ten = Console.ReadLine();

                Console.Write("Lương cơ bản: ");
                double lcb = double.Parse(Console.ReadLine());

                switch (loai)
                {
                    case 1:
                        Console.Write("Số ngày làm việc: ");
                        int ngay = int.Parse(Console.ReadLine());

                        danhSach.Add(
                            new NhanVienVanPhong(
                                ma,
                                ten,
                                lcb,
                                ngay));
                        break;

                    case 2:
                        Console.Write("Doanh số: ");
                        double ds = double.Parse(Console.ReadLine());

                        danhSach.Add(
                            new NhanVienKinhDoanh(
                                ma,
                                ten,
                                lcb,
                                ds));
                        break;

                    case 3:
                        Console.Write("Số giờ làm: ");
                        int gio = int.Parse(Console.ReadLine());

                        Console.Write("Lương theo giờ: ");
                        double lg = double.Parse(Console.ReadLine());

                        danhSach.Add(
                            new NhanVienThoiVu(
                                ma,
                                ten,
                                lcb,
                                gio,
                                lg));
                        break;
                }
            }

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
                            Console.WriteLine();
                        }
                        break;

                    case 2:
                        Console.Write("Nhập mã cần tìm: ");
                        string maTim = Console.ReadLine();

                        NhanVien nvTim =
                            danhSach.Find(x => x.MaNV == maTim);

                        if (nvTim != null)
                            nvTim.HienThiThongTin();
                        else
                            Console.WriteLine("Không tìm thấy!");
                        break;

                    case 3:
                        double maxLuong =
                            danhSach.Max(x => x.TinhLuong());

                        List<NhanVien> dsMax =
                            danhSach.FindAll(
                                x => x.TinhLuong() == maxLuong);

                        Console.WriteLine("\nNhân viên lương cao nhất:");

                        foreach (NhanVien nv in dsMax)
                        {
                            nv.HienThiThongTin();
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        double tongLuong = 0;

                        foreach (NhanVien nv in danhSach)
                        {
                            tongLuong += nv.TinhLuong();
                        }

                        Console.WriteLine(
                            $"Tổng lương công ty phải trả: {tongLuong:N0}");
                        break;
                }

            } while (chon != 0);
        }
    }
}
