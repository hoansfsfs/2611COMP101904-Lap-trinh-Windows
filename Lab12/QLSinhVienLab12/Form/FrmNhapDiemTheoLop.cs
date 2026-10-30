using System;
using System.Data;
using System.Windows.Forms;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL =
            new KetQuaDAL();

        private readonly BindingSource source =
            new BindingSource();

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        private void FrmNhapDiemTheoLop_Load(
            object sender,
            EventArgs e)
        {
            LoadComboBox();

            dgvKetQua.AutoGenerateColumns = true;
            dgvKetQua.DataSource = source;
        }

        private void LoadComboBox()
        {
            cboLop.DataSource =
                ketQuaDAL.GetLop();

            cboLop.DisplayMember =
                "TenLop";

            cboLop.ValueMember =
                "MaLop";

            cboMonHoc.DataSource =
                ketQuaDAL.GetMonHoc();

            cboMonHoc.DisplayMember =
                "TenMon";

            cboMonHoc.ValueMember =
                "MaMon";
        }

        private void btnTaiDanhSach_Click(
            object sender,
            EventArgs e)
        {
            string maLop =
                cboLop.SelectedValue.ToString();

            string maMon =
                cboMonHoc.SelectedValue.ToString();

            source.DataSource =
                ketQuaDAL.GetKetQua(maLop, maMon);

            lblTrangThai.Text =
                "Đã tải danh sách sinh viên";
        }

        private void btnLuuTatCa_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                source.EndEdit();

                DataTable table =
                    (DataTable)source.DataSource;

                ValidateData(table);

                string maMon =
                    cboMonHoc.SelectedValue.ToString();

                int count =
                    ketQuaDAL.SaveAll(
                        maMon,
                        table);

                lblTrangThai.Text =
                    $"Đã lưu {count} dòng";

                MessageBox.Show(
                    "Lưu dữ liệu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                lblTrangThai.Text =
                    "Lưu thất bại";
            }
        }

        private void ValidateData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                string maSV =
                    row["MaSV"].ToString();

                if (!double.TryParse(
                        row["Diem"].ToString(),
                        out double diem))
                {
                    throw new Exception(
                        $"Điểm sinh viên {maSV} không hợp lệ");
                }

                if (diem < 0 || diem > 10)
                {
                    throw new Exception(
                        $"Điểm sinh viên {maSV} phải từ 0 đến 10");
                }
            }
        }
    }
}
