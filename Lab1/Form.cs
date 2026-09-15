private void btnHienThi_Click(object sender, EventArgs e)
{
    // Kiểm tra họ tên
    if (txtHoTen.Text.Trim() == "")
    {
        MessageBox.Show("Họ tên không được rỗng!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        txtHoTen.Focus();
        return;
    }

    // Kiểm tra năm sinh
    if (txtNamSinh.Text.Trim() == "")
    {
        MessageBox.Show("Năm sinh không được rỗng!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        txtNamSinh.Focus();
        return;
    }

    // Kiểm tra năm sinh có phải số nguyên không
    int namSinh;

    if (!int.TryParse(txtNamSinh.Text, out namSinh))
    {
        MessageBox.Show("Năm sinh phải là số nguyên!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        txtNamSinh.Focus();
        return;
    }

    // Kiểm tra khoảng năm sinh
    int namHienTai = DateTime.Now.Year;

    if (namSinh < 1900 || namSinh > namHienTai)
    {
        MessageBox.Show("Năm sinh phải từ 1900 đến " + namHienTai + "!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        txtNamSinh.Focus();
        return;
    }

    // Kiểm tra Email
    if (txtEmail.Text.Trim() == "")
    {
        MessageBox.Show("Email không được rỗng!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        txtEmail.Focus();
        return;
    }

    // Kiểm tra giới tính
    if (!radNam.Checked && !radNu.Checked)
    {
        MessageBox.Show("Vui lòng chọn giới tính!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        return;
    }

    if (cboKhoa.SelectedIndex == -1)
    {
        MessageBox.Show("Vui lòng chọn khoa hoặc lớp!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        cboKhoa.Focus();
        return;
    }

    int tuoi = namHienTai - namSinh;

    string gioiTinh;

    if (radNam.Checked)
    {
        gioiTinh = "Nam";
    }
    else
    {
        gioiTinh = "Nữ";
    }

    string ketQua = "THÔNG TIN SINH VIÊN\r\n"
                  + "Họ tên: " + txtHoTen.Text.Trim() + "\r\n"
                  + "Tuổi: " + tuoi + "\r\n"
                  + "Email: " + txtEmail.Text.Trim() + "\r\n"
                  + "Giới tính: " + gioiTinh + "\r\n"
                  + "Khoa/Lớp: " + cboKhoa.Text;

    txtKetQua.Text = ketQua;
}
