namespace Lab11_QuanLyLop
{
    partial class FrmLop
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.Label lblTenLop;

        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvLop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaLop = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();

            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvLop = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();

            this.SuspendLayout();

            // lblMaLop
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(30, 30);
            this.lblMaLop.Text = "Mã lớp";

            // txtMaLop
            this.txtMaLop.Location = new System.Drawing.Point(120, 27);
            this.txtMaLop.Size = new System.Drawing.Size(250, 22);

            // lblTenLop
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(30, 70);
            this.lblTenLop.Text = "Tên lớp";

            // txtTenLop
            this.txtTenLop.Location = new System.Drawing.Point(120, 67);
            this.txtTenLop.Size = new System.Drawing.Size(250, 22);

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(420, 20);
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(520, 20);
            this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(620, 20);
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLamMoi
            this.btnLamMoi.Location = new System.Drawing.Point(420, 65);
            this.btnLamMoi.Size = new System.Drawing.Size(140, 35);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(30, 120);
            this.txtTimKiem.Size = new System.Drawing.Size(350, 22);

            // btnTimKiem
            this.btnTimKiem.Location = new System.Drawing.Point(400, 115);
            this.btnTimKiem.Size = new System.Drawing.Size(120, 30);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // dgvLop
            this.dgvLop.Location = new System.Drawing.Point(30, 170);
            this.dgvLop.Size = new System.Drawing.Size(760, 250);
            this.dgvLop.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLop.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvLop_CellClick);

            // FrmLop
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.lblMaLop);
            this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.lblTenLop);
            this.Controls.Add(this.txtTenLop);

            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);

            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);

            this.Controls.Add(this.dgvLop);

            this.Text = "Quản lý lớp học";
            this.Load += new System.EventHandler(this.FrmLop_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
