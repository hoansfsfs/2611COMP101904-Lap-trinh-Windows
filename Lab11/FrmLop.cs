using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Lab11_QuanLyLop
{
    public partial class FrmLop : Form
    {
        private readonly string connectionString =
            @"Data Source=.;
              Initial Catalog=EduManagerDB;
              Integrated Security=True;
              TrustServerCertificate=True";

        public FrmLop()
        {
            InitializeComponent();
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql =
            @"SELECT l.MaLop,
                     l.TenLop,
                     COUNT(sv.MaSV) SoSinhVien
              FROM LOP l
              LEFT JOIN SINHVIEN sv
                     ON l.MaLop = sv.MaLop
              GROUP BY l.MaLop,l.TenLop";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlDataAdapter da =
                new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvLop.DataSource = dt;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Nhập mã lớp");
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Nhập tên lớp");
                txtTenLop.Focus();
                return false;
            }

            return true;
        }

        private bool IsMaLopExists(string ma)
        {
            string sql =
                "SELECT COUNT(*) FROM LOP WHERE MaLop=@ma";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma", ma);

            conn.Open();

            int count =
                Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }

        private int CountSinhVien(string ma)
        {
            string sql =
                "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop=@ma";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma", ma);

            conn.Open();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            if (IsMaLopExists(ma))
            {
                MessageBox.Show("Mã lớp đã tồn tại");
                return;
            }

            string sql =
                "INSERT INTO LOP VALUES(@ma,@ten)";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma", ma);
            cmd.Parameters.AddWithValue("@ten", ten);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
                ClearInput();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql =
                "UPDATE LOP SET TenLop=@ten WHERE MaLop=@ma";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma",
                txtMaLop.Text.Trim());

            cmd.Parameters.AddWithValue("@ten",
                txtTenLop.Text.Trim());

            conn.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Cập nhật thành công");

            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();

            if (CountSinhVien(ma) > 0)
            {
                MessageBox.Show(
                    "Không thể xóa lớp đang có sinh viên");

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            string sql =
                "DELETE FROM LOP WHERE MaLop=@ma";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma", ma);

            conn.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Xóa thành công");

            LoadData();
            ClearInput();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql =
            @"SELECT *
              FROM LOP
              WHERE MaLop LIKE @kw
              OR TenLop LIKE @kw";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@kw",
                "%" + txtTimKiem.Text.Trim() + "%");

            DataTable dt = new DataTable();

            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            da.Fill(dt);

            dgvLop.DataSource = dt;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            txtMaLop.Enabled = true;
            LoadData();
        }

        private void dgvLop_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtMaLop.Text =
                dgvLop.Rows[e.RowIndex]
                      .Cells["MaLop"]
                      .Value.ToString();

            txtTenLop.Text =
                dgvLop.Rows[e.RowIndex]
                      .Cells["TenLop"]
                      .Value.ToString();

            txtMaLop.Enabled = false;
        }

        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            txtMaLop.Focus();
        }
    }
}
