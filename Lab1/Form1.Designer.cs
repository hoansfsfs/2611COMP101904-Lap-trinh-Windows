namespace QuanLyThongTinSinhVien
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblHoTen;
        private Label lblNamSinh;
        private Label lblEmail;
        private Label lblKhoa;

        private TextBox txtHoTen;
        private TextBox txtNamSinh;
        private TextBox txtEmail;

        private GroupBox grpGioiTinh;
        private RadioButton radNam;
        private RadioButton radNu;

        private ComboBox cboKhoa;

        private Button btnHienThi;
        private Button btnXoa;
        private Button btnThoat;

        private TextBox txtKetQua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblHoTen = new Label();
            lblNamSinh = new Label();
            lblEmail = new Label();
            lblKhoa = new Label();

            txtHoTen = new TextBox();
            txtNamSinh = new TextBox();
            txtEmail = new TextBox();

            grpGioiTinh = new GroupBox();
            radNam = new RadioButton();
            radNu = new RadioButton();

            cboKhoa = new ComboBox();

            btnHienThi = new Button();
            btnXoa = new Button();
            btnThoat = new Button();

            txtKetQua = new TextBox();

            grpGioiTinh.SuspendLayout();
            SuspendLayout();

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 590);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cá nhân sinh viên";
            Load += Form1_Load;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(80, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(465, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ỨNG DỤNG THÔNG TIN CÁ NHÂN";

            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Arial", 11F);
            lblHoTen.Location = new Point(45, 105);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(65, 22);
            lblHoTen.Text = "Họ tên:";

            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Arial", 11F);
            txtHoTen.Location = new Point(190, 100);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(380, 28);

            // 
            // lblNamSinh
            // 
            lblNamSinh.AutoSize = true;
            lblNamSinh.Font = new Font("Arial", 11F);
            lblNamSinh.Location = new Point(45, 150);
            lblNamSinh.Name = "lblNamSinh";
            lblNamSinh.Size = new Size(82, 22);
            lblNamSinh.Text = "Năm sinh:";

            // 
            // txtNamSinh
            // 
            txtNamSinh.Font = new Font("Arial", 11F);
            txtNamSinh.Location = new Point(190, 145);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(380, 28);

            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Arial", 11F);
            lblEmail.Location = new Point(45, 195);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 22);
            lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial", 11F);
            txtEmail.Location = new Point(190, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 28);

            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(radNu);
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Font = new Font("Arial", 11F);
            grpGioiTinh.Location = new Point(40, 235);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(530, 65);
            grpGioiTinh.TabIndex = 4;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";

            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(25, 27);
            radNam.Name = "radNam";
            radNam.Size = new Size(63, 26);
            radNam.TabIndex = 0;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;

            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(120, 27);
            radNu.Name = "radNu";
            radNu.Size = new Size(54, 26);
            radNu.TabIndex = 1;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;

            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Font = new Font("Arial", 11F);
            lblKhoa.Location = new Point(45, 325);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(93, 22);
            lblKhoa.Text = "Khoa/Lớp:";

            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.Font = new Font("Arial", 11F);
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(190, 320);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(380, 28);

            // 
            // btnHienThi
            // 
            btnHienThi.Font = new Font("Arial", 11F);
            btnHienThi.Location = new Point(40, 370);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(155, 40);
            btnHienThi.TabIndex = 6;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;

            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Arial", 11F);
            btnXoa.Location = new Point(215, 370);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(155, 40);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Arial", 11F);
            btnThoat.Location = new Point(395, 370);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(175, 40);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;

            // 
            // txtKetQua
            // 
            txtKetQua.Font = new Font("Arial", 11F);
            txtKetQua.Location = new Point(40, 430);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.ScrollBars = ScrollBars.Vertical;
            txtKetQua.Size = new Size(530, 120);
            txtKetQua.TabIndex = 9;

            // 
            // Add controls
            // 
            Controls.Add(lblTitle);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblNamSinh);
            Controls.Add(txtNamSinh);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(grpGioiTinh);
            Controls.Add(lblKhoa);
            Controls.Add(cboKhoa);
            Controls.Add(btnHienThi);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);
            Controls.Add(txtKetQua);

            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
