namespace QuanLyThongTinSinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ==============================
        // FORM LOAD
        // ==============================
        private void Form1_Load(object sender, EventArgs e)
        {
            // Thêm dữ liệu cho ComboBox
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Kinh tế");
            cboKhoa.Items.Add("Ngoại ngữ");
            cboKhoa.Items.Add("Quản trị kinh doanh");

            // Ban đầu không chọn khoa
            cboKhoa.SelectedIndex = -1;

            // Đưa con trỏ vào ô Họ tên
            txtHoTen.Focus();
        }


        // ==============================
        // NÚT HIỂN THỊ
        // ==============================
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // --------------------------------
            // 1. Kiểm tra họ tên
            // --------------------------------
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHoTen.Focus();
                return;
            }


            // --------------------------------
            // 2. Kiểm tra năm sinh rỗng
            // --------------------------------
            if (txtNamSinh.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập năm sinh.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNamSinh.Focus();
                return;
            }


            // --------------------------------
            // 3. Kiểm tra năm sinh là số nguyên
            // --------------------------------
            int namSinh;

            if (!int.TryParse(txtNamSinh.Text.Trim(), out namSinh))
            {
                MessageBox.Show(
                    "Năm sinh phải là số nguyên.",
                    "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtNamSinh.Focus();
                txtNamSinh.SelectAll();
                return;
            }


            // --------------------------------
            // 4. Kiểm tra khoảng năm sinh
            // --------------------------------
            int namHienTai = DateTime.Now.Year;

            if (namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show(
                    "Năm sinh phải nằm trong khoảng từ 1900 đến "
                    + namHienTai + ".",
                    "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtNamSinh.Focus();
                txtNamSinh.SelectAll();
                return;
            }


            // --------------------------------
            // 5. Kiểm tra Email
            // --------------------------------
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập email.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }


            // --------------------------------
            // 6. Kiểm tra giới tính
            // --------------------------------
            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show(
                    "Vui lòng chọn giới tính.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // --------------------------------
            // 7. Kiểm tra khoa/lớp
            // --------------------------------
            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn khoa hoặc lớp.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cboKhoa.Focus();
                return;
            }


            // --------------------------------
            // 8. Tính tuổi
            // --------------------------------
            int tuoi = namHienTai - namSinh;


            // --------------------------------
            // 9. Xác định giới tính
            // --------------------------------
            string gioiTinh;

            if (radNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }


            // --------------------------------
            // 10. Lấy khoa/lớp
            // --------------------------------
            string khoa = cboKhoa.Text;


            // --------------------------------
            // 11. Tạo kết quả
            // --------------------------------
            string ketQua =
                "THÔNG TIN SINH VIÊN\r\n"
                + "Họ tên: " + txtHoTen.Text.Trim() + "\r\n"
                + "Tuổi: " + tuoi + "\r\n"
                + "Email: " + txtEmail.Text.Trim() + "\r\n"
                + "Giới tính: " + gioiTinh + "\r\n"
                + "Khoa/Lớp: " + khoa;


            // --------------------------------
            // 12. Hiển thị kết quả
            // --------------------------------
            txtKetQua.Text = ketQua;
        }


        // ==============================
        // NÚT XÓA
        // ==============================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa họ tên
            txtHoTen.Clear();

            // Xóa năm sinh
            txtNamSinh.Clear();

            // Xóa email
            txtEmail.Clear();

            // Bỏ chọn giới tính
            radNam.Checked = false;
            radNu.Checked = false;

            // Không chọn ComboBox
            cboKhoa.SelectedIndex = -1;

            // Xóa kết quả
            txtKetQua.Clear();

            // Đưa con trỏ về ô họ tên
            txtHoTen.Focus();
        }


        // ==============================
        // NÚT THOÁT
        // ==============================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
