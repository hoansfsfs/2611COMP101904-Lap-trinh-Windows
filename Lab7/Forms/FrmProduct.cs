private BindingList<Product> products = new()
{
    new Product
    {
        MaSP = "SP01",
        TenSP = "Chuột không dây",
        LoaiSP = "Điện tử",
        DonGia = 150000,
        SoLuong = 20
    },

    new Product
    {
        MaSP = "SP02",
        TenSP = "Bút bi",
        LoaiSP = "Văn phòng",
        DonGia = 5000,
        SoLuong = 100
    },

    new Product
    {
        MaSP = "SP03",
        TenSP = "Nồi cơm điện",
        LoaiSP = "Gia dụng",
        DonGia = 1200000,
        SoLuong = 10
    }
};

private BindingSource source = new();
