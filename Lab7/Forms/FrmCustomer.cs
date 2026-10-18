private BindingList<Customer> customers =
    new BindingList<Customer>();

private void btnAdd_Click(
    object sender,
    EventArgs e)
{
    customers.Add(new Customer
    {
        MaKH = txtMaKH.Text,
        HoTen = txtHoTen.Text,
        SoDienThoai = txtPhone.Text,
        LoaiKhachHang = cboLoai.Text
    });
}
