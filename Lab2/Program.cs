using System;

class Program
{
    // Nhập một số nguyên
    static int NhapSoNguyen(string message)
    {
        int value;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }

            Console.WriteLine("Du lieu khong hop le. Vui long nhap lai!");
        }
    }

    // Nhập số nguyên dương
    static int NhapSoNguyenDuong(string message)
    {
        int value;

        while (true)
        {
            value = NhapSoNguyen(message);

            if (value > 0)
            {
                return value;
            }

            Console.WriteLine("So phan tu phai la so nguyen duong!");
        }
    }

    // Nhập mảng
    static int[] NhapMang()
    {
        int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = NhapSoNguyen("Nhap a[" + i + "]: ");
        }

        Console.WriteLine("Da nhap mang thanh cong!");

        return a;
    }

    // Xuất mảng
    static void XuatMang(int[] a)
    {
        Console.Write("Mang: ");

        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }

        Console.WriteLine();
    }

    // Tính tổng
    static int TinhTong(int[] a)
    {
        int tong = 0;

        for (int i = 0; i < a.Length; i++)
        {
            tong += a[i];
        }

        return tong;
    }

    // Tìm giá trị lớn nhất
    static int TimMax(int[] a)
    {
        int max = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
            }
        }

        return max;
    }

    // Tìm giá trị nhỏ nhất
    static int TimMin(int[] a)
    {
        int min = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < min)
            {
                min = a[i];
            }
        }

        return min;
    }

    // Đếm số chẵn
    static int DemChan(int[] a)
    {
        int dem = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 == 0)
            {
                dem++;
            }
        }

        return dem;
    }

    // Đếm số lẻ
    static int DemLe(int[] a)
    {
        int dem = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 != 0)
            {
                dem++;
            }
        }

        return dem;
    }

    // Sắp xếp tăng dần
    static void SapXepTangDan(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i] > a[j])
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
        }
    }

    // Tìm kiếm
    // Trả về vị trí đầu tiên nếu tìm thấy
    // Trả về -1 nếu không tìm thấy
    static int TimKiem(int[] a, int x)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == x)
            {
                return i;
            }
        }

        return -1;
    }

    // Hiển thị menu
    static void HienThiMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== MENU =====");
        Console.WriteLine("1. Nhap mang");
        Console.WriteLine("2. Xuat mang");
        Console.WriteLine("3. Tinh tong");
        Console.WriteLine("4. Tim max/min");
        Console.WriteLine("5. Dem chan/le");
        Console.WriteLine("6. Sap xep tang dan");
        Console.WriteLine("7. Tim kiem");
        Console.WriteLine("0. Thoat");
        Console.WriteLine("================");
    }

    static void Main()
    {
        int[] a = null;
        int luaChon;

        do
        {
            HienThiMenu();

            luaChon = NhapSoNguyen("Chon chuc nang: ");

            switch (luaChon)
            {
                case 1:
                    a = NhapMang();
                    break;

                case 2:
                    if (a == null)
                    {
                        Console.WriteLine("Chua nhap mang!");
                    }
                    else
                    {
                        XuatMang(a);
                    }
                    break;

                case 3:
                    if (a == null)
                    {
                        Console.WriteLine("Chua nhap mang!");
                    }
                    else
                    {
                        Console.WriteLine("Tong = " + TinhTong(a));
                    }
                    break;

                case 4:
                    if (a == null)
                    {
                        Console.WriteLine("Chua nhap mang!");
                    }
                    else
                    {
                        Console.WriteLine("Max = " + TimMax(a));
                        Console.WriteLine("Min = " + TimMin(a));
                    }
                    break;

                case 5:
                    if (a == null)
                    {
                        Console.WriteLine("Chua nhap mang!");
                    }
                    else
                    {
                        Console.WriteLine("So phan tu chan = " + DemChan(a));
                        Console.WriteLine("So phan tu le = " + DemLe(a));
                    }
                    break;

                case 6:
                    if (a == null)
                    {
                        Console.WriteLine("Chua nhap mang!");
                    }
                    else
                    {
                        SapXepTangDan(a);
                        Console.WriteLine("Mang sau khi sap xep tang dan:");
                        XuatMang(a);
                    }
                    break;

                case 7:
                    if (a == null)
                    {
                        Console.WriteLine("Chua nhap mang!");
                    }
                    else
                    {
                        int x = NhapSoNguyen("Nhap gia tri x: ");
                        int viTri = TimKiem(a, x);

                        if (viTri == -1)
                        {
                            Console.WriteLine("Khong tim thay " + x + " trong mang.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Tim thay " + x +
                                " tai vi tri dau tien: " + viTri);
                        }
                    }
                    break;

                case 0:
                    Console.WriteLine("Ket thuc chuong trinh!");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                    break;
            }

        } while (luaChon != 0);
    }
}
