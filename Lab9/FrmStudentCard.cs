using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace InTheSinhVien
{
    public partial class FrmStudentCard : Form
    {
        public FrmStudentCard()
        {
            InitializeComponent();
        }

        private void FrmStudentCard_Load(
            object sender,
            EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            dtpNgaySinh.MinDate = new DateTime(1990, 1, 1);
            dtpNgaySinh.MaxDate = DateTime.Today;

            dtpNgaySinh.Value = new DateTime(2005, 1, 1);


            cboLop.Items.AddRange(new object[]
            {
                "K49.CNTT.A",
                "K50.CNTT.A",
                "K51.CNTT.A"
            });

            cboKhoa.Items.AddRange(new object[]
            {
                "Công nghệ thông tin",
                "Toán - Tin học"
            });

            cboKhoaHoc.Items.AddRange(new object[]
            {
                "K49",
                "K50",
                "K51"
            });

            cboGioiTinh.Items.AddRange(new object[]
            {
                "Nam",
                "Nữ",
                "Khác"
            });

            cboLop.SelectedIndex = 0;
            cboKhoa.SelectedIndex = 0;
            cboKhoaHoc.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;

            btnChonAnh.Click += btnChonAnh_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnThoat.Click += btnThoat_Click;
            btnXemTruocIn.Click += btnXemTruocIn_Click;
            btnIn.Click += btnIn_Click;

            pnlXemTruoc.Paint += pnlXemTruoc_Paint;

            txtMaSV.TextChanged += InputChanged;
            txtHoTen.TextChanged += InputChanged;

            cboLop.SelectedIndexChanged += InputChanged;
            cboKhoa.SelectedIndexChanged += InputChanged;
            cboKhoaHoc.SelectedIndexChanged += InputChanged;
            cboGioiTinh.SelectedIndexChanged += InputChanged;

            dtpNgaySinh.ValueChanged += InputChanged;

            docInThe.PrintPage += docInThe_PrintPage;
        }

        private void InputChanged(
            object sender,
            EventArgs e)
        {
            pnlXemTruoc.Invalidate();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã sinh viên.");

                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên.");

                txtHoTen.Focus();
                return false;
            }

            if (picAnhDaiDien.Image == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn ảnh đại diện.");

                return false;
            }

            return true;
        }

        private void btnChonAnh_Click(
            object sender,
            EventArgs e)
        {
            dlgChonAnh.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlgChonAnh.ShowDialog()
                == DialogResult.OK)
            {
                picAnhDaiDien.Image =
                    Image.FromFile(
                        dlgChonAnh.FileName);

                pnlXemTruoc.Invalidate();
            }
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();

            picAnhDaiDien.Image = null;

            pnlXemTruoc.Invalidate();
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void pnlXemTruoc_Paint(
            object sender,
            PaintEventArgs e)
        {
            DrawStudentCard(
                e.Graphics,
                new Rectangle(
                    20,
                    20,
                    700,
                    250));
        }

        private void DrawStudentCard(
            Graphics g,
            Rectangle card)
        {
            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            g.FillRectangle(
                Brushes.White,
                card);

            g.DrawRectangle(
                Pens.Navy,
                card);

            Font titleFont =
                new Font(
                    "Arial",
                    16,
                    FontStyle.Bold);

            Font textFont =
                new Font(
                    "Arial",
                    10);

            g.DrawString(
                "THẺ SINH VIÊN",
                titleFont,
                Brushes.Navy,
                card.Left + 220,
                card.Top + 20);

            Rectangle photoBox =
                new Rectangle(
                    card.Left + 20,
                    card.Top + 60,
                    120,
                    140);

            g.DrawRectangle(
                Pens.Gray,
                photoBox);

            if (picAnhDaiDien.Image != null)
            {
                g.DrawImage(
                    picAnhDaiDien.Image,
                    photoBox);
            }

            int x = card.Left + 180;
            int y = card.Top + 70;

            g.DrawString(
                "MSSV: " + txtMaSV.Text,
                textFont,
                Brushes.Black,
                x,
                y);

            g.DrawString(
                "Họ tên: " + txtHoTen.Text,
                textFont,
                Brushes.Black,
                x,
                y + 30);

            g.DrawString(
                "Lớp: " + cboLop.Text,
                textFont,
                Brushes.Black,
                x,
                y + 60);

            g.DrawString(
                "Khoa: " + cboKhoa.Text,
                textFont,
                Brushes.Black,
                x,
                y + 90);

            g.DrawString(
                "Khóa học: " + cboKhoaHoc.Text,
                textFont,
                Brushes.Black,
                x,
                y + 120);

            g.DrawString(
                "Ngày sinh: " +
                dtpNgaySinh.Value.ToString("dd/MM/yyyy"),
                textFont,
                Brushes.Black,
                x,
                y + 150);
        }

        private void btnXemTruocIn_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateInput())
                return;

            dlgXemTruocIn.Document =
                docInThe;

            dlgXemTruocIn.ShowDialog();
        }

        private void btnIn_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateInput())
                return;

            dlgIn.Document =
                docInThe;

            if (dlgIn.ShowDialog()
                == DialogResult.OK)
            {
                docInThe.Print();
            }
        }

        private void docInThe_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            DrawStudentCard(
                e.Graphics,
                new Rectangle(
                    50,
                    50,
                    700,
                    250));

            e.HasMorePages = false;
        }
    }
}