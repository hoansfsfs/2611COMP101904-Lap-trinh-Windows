using StudentReportDemo.Models;
using System.Text;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private List<SinhVien> danhSachSinhVien =
            new List<SinhVien>();

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoSinhVien_Load(
            object sender,
            EventArgs e)
        {
            TaoDuLieuMau();

            LoadComboBox();

            XemBaoCao();
        }

        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>()
            {
                new SinhVien
                {
                    MaSV="SV001",
                    HoTen="Nguyễn Văn An",
                    MaLop="CTK47A",
                    TenLop="CNTT K47A",
                    Diem=8.2
                },

                new SinhVien
                {
                    MaSV="SV002",
                    HoTen="Trần Thị Bình",
                    MaLop="CTK47A",
                    TenLop="CNTT K47A",
                    Diem=6.5
                },

                new SinhVien
                {
                    MaSV="SV003",
                    HoTen="Lê Minh Cường",
                    MaLop="CTK47A",
                    TenLop="CNTT K47A",
                    Diem=4.8
                },

                new SinhVien
                {
                    MaSV="SV004",
                    HoTen="Phạm Thanh Dung",
                    MaLop="CTK47A",
                    TenLop="CNTT K47A",
                    Diem=9.1
                },

                new SinhVien
                {
                    MaSV="SV005",
                    HoTen="Hoàng Quốc Huy",
                    MaLop="CTK47B",
                    TenLop="CNTT K47B",
                    Diem=7.4
                },

                new SinhVien
                {
                    MaSV="SV006",
                    HoTen="Võ Gia Khang",
                    MaLop="CTK47B",
                    TenLop="CNTT K47B",
                    Diem=3.9
                },

                new SinhVien
                {
                    MaSV="SV007",
                    HoTen="Đặng Minh Khôi",
                    MaLop="CTK47B",
                    TenLop="CNTT K47B",
                    Diem=5.5
                },

                new SinhVien
                {
                    MaSV="SV008",
                    HoTen="Bùi Thảo Linh",
                    MaLop="CTK47B",
                    TenLop="CNTT K47B",
                    Diem=8.0
                },

                new SinhVien
                {
                    MaSV="SV009",
                    HoTen="Ngô Tuấn Minh",
                    MaLop="CTK48A",
                    TenLop="CNTT K48A",
                    Diem=6.0
                },

                new SinhVien
                {
                    MaSV="SV010",
                    HoTen="Đỗ Bảo Ngọc",
                    MaLop="CTK48A",
                    TenLop="CNTT K48A",
                    Diem=9.3
                },

                new SinhVien
                {
                    MaSV="SV011",
                    HoTen="Huỳnh Gia Phúc",
                    MaLop="CTK48A",
                    TenLop="CNTT K48A",
                    Diem=4.2
                },

                new SinhVien
                {
                    MaSV="SV012",
                    HoTen="Mai Anh Thư",
                    MaLop="CTK48A",
                    TenLop="CNTT K48A",
                    Diem=7.8
                }
            };
        }

        private void LoadComboBox()
        {
            var dsLop = danhSachSinhVien
                .Select(x => new
                {
                    x.MaLop,
                    x.TenLop
                })
                .Distinct()
                .OrderBy(x => x.MaLop)
                .ToList();

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboKetQua.Items.Clear();

            cboKetQua.Items.Add("Tất cả");
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");

            cboKetQua.SelectedIndex = 0;
        }

        private void XemBaoCao()
        {
            if (cboLop.SelectedValue == null)
                return;

            string maLop =
                cboLop.SelectedValue.ToString();

            string ketQua =
                cboKetQua.Text;

            string tuKhoa =
                txtTuKhoa.Text.Trim()
                             .ToLower();

            var query =
                danhSachSinhVien.Where(
                    x => x.MaLop == maLop);

            if (ketQua == "Đạt")
            {
                query =
                    query.Where(
                        x => x.Diem >= 5);
            }

            if (ketQua == "Không đạt")
            {
                query =
                    query.Where(
                        x => x.Diem < 5);
            }

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query =
                    query.Where(x =>
                        x.MaSV.ToLower()
                         .Contains(tuKhoa)
                         ||
                        x.HoTen.ToLower()
                         .Contains(tuKhoa));
            }

            var ketQuaBaoCao =
                query
                .OrderByDescending(x => x.Diem)
                .ThenBy(x => x.HoTen)
                .Select(x => new
                {
                    x.MaSV,
                    x.HoTen,
                    x.TenLop,
                    x.Diem,
                    x.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource =
                ketQuaBaoCao;

            CapNhatThongKe(
                ketQuaBaoCao.Count);

            if (ketQuaBaoCao.Count == 0)
            {
                MessageBox.Show(
                    "Không có dữ liệu phù hợp");
            }
        }

        private void CapNhatThongKe(
            int soDong)
        {
            string maLop =
                cboLop.SelectedValue?.ToString()
                ?? "";

            var ds =
                danhSachSinhVien
                .Where(x => x.MaLop == maLop)
                .ToList();

            int tong = ds.Count;

            int dat =
                ds.Count(x => x.Diem >= 5);

            int khongDat =
                ds.Count(x => x.Diem < 5);

            double dtb =
                tong > 0
                ? ds.Average(x => x.Diem)
                : 0;

            lblThongKe.Text =
                $"Hiển thị: {soDong} | " +
                $"Tổng: {tong} | " +
                $"Đạt: {dat} | " +
                $"Không đạt: {khongDat} | " +
                $"ĐTB: {dtb:0.00}";
        }

        private void btnXemBaoCao_Click(
            object sender,
            EventArgs e)
        {
            XemBaoCao();
        }

        private void btnThongKe_Click(
            object sender,
            EventArgs e)
        {
            var tk =
                danhSachSinhVien
                .GroupBy(x => new
                {
                    x.MaLop,
                    x.TenLop
                })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat =
                        g.Count(x => x.Diem >= 5),
                    SoKhongDat =
                        g.Count(x => x.Diem < 5),

                    DiemTrungBinh =
                        Math.Round(
                            g.Average(x => x.Diem),
                            2)
                })
                .ToList();

            dgvBaoCao.DataSource = tk;

            lblThongKe.Text =
                "Thống kê theo lớp";
        }

        private void btnXuatFile_Click(
            object sender,
            EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không có dữ liệu để xuất");
                return;
            }

            SaveFileDialog sfd =
                new SaveFileDialog();

            sfd.Filter =
                "CSV File (*.csv)|*.csv|Text File (*.txt)|*.txt";

            sfd.FileName =
                "BaoCaoSinhVien.csv";

            if (sfd.ShowDialog()
                != DialogResult.OK)
                return;

            try
            {
                StringBuilder sb =
                    new StringBuilder();

                for (int i = 0;
                     i < dgvBaoCao.Columns.Count;
                     i++)
                {
                    sb.Append(
                        dgvBaoCao.Columns[i]
                        .HeaderText);

                    if (i <
                        dgvBaoCao.Columns.Count - 1)
                        sb.Append(",");
                }

                sb.AppendLine();

                foreach (DataGridViewRow row
                    in dgvBaoCao.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    for (int i = 0;
                         i < dgvBaoCao.Columns.Count;
                         i++)
                    {
                        string value =
                            row.Cells[i]
                            .Value?.ToString()
                            ?? "";

                        value =
                            value.Replace(",", " ");

                        sb.Append(value);

                        if (i <
                            dgvBaoCao.Columns.Count - 1)
                            sb.Append(",");
                    }

                    sb.AppendLine();
                }

                File.WriteAllText(
                    sfd.FileName,
                    sb.ToString(),
                    Encoding.UTF8);

                MessageBox.Show(
                    "Xuất file thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}
