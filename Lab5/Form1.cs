using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseRegistrationApp
{
    public partial class Form1 : Form
    {
        private Dictionary<string, decimal> khoaHocHocPhi;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            khoaHocHocPhi = new Dictionary<string, decimal>()
            {
                { "C# WinForms cơ bản", 800000 },
                { "SQL Server cơ bản", 700000 },
                { "Web Frontend cơ bản", 750000 },
                { "Lập trình Python cơ bản", 650000 }
            };

            cboKhoaHoc.Items.AddRange(new object[]
            {
                "C# WinForms cơ bản",
                "SQL Server cơ bản",
                "Web Frontend cơ bản",
                "Lập trình Python cơ bản"
            });

            cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;

            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            if (cboKhoaHoc.SelectedItem == null)
                return;

            string khoaHoc = cboKhoaHoc.SelectedItem.ToString();
            decimal hocPhi = khoaHocHocPhi[khoaHoc];
            decimal tongTien = hocPhi * numSoThang.Value;

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn khóa học!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            string khoaHoc = cboKhoaHoc.SelectedItem.ToString();

            string hinhThucHoc = radOnline.Checked
                ? "Online"
                : "Offline";

            int soThang = (int)numSoThang.Value;

            decimal tongTien =
                khoaHocHocPhi[khoaHoc] * soThang;

            string nhanEmail =
                chkNhanEmail.Checked
                ? "Có"
                : "Không";

            string thongTin =
                "PHIẾU ĐĂNG KÝ KHÓA HỌC\n\n" +
                $"Họ tên: {hoTen}\n" +
                $"Số điện thoại: {soDienThoai}\n" +
                $"Ngày sinh: {ngaySinh}\n" +
                $"Khóa học: {khoaHoc}\n" +
                $"Hình thức học: {hinhThucHoc}\n" +
                $"Số tháng: {soThang}\n" +
                $"Tổng học phí: {tongTien:N0} VNĐ\n" +
                $"Nhận email: {nhanEmail}";

            MessageBox.Show(
                thongTin,
                "Kết quả đăng ký",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();

            dtpNgaySinh.Value = DateTime.Now;

            chkNhanEmail.Checked = false;

            cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;

            numSoThang.Value = 1;

            txtHoTen.Focus();

            CapNhatTongTien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}  
