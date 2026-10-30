private System.Windows.Forms.ComboBox cboLop;
private System.Windows.Forms.ComboBox cboMonHoc;
private System.Windows.Forms.Button btnTaiDanhSach;
private System.Windows.Forms.Button btnLuuTatCa;
private System.Windows.Forms.DataGridView dgvKetQua;
private System.Windows.Forms.Label lblTrangThai;

private void InitializeComponent()
{
    this.cboLop = new ComboBox();
    this.cboMonHoc = new ComboBox();

    this.btnTaiDanhSach = new Button();
    this.btnLuuTatCa = new Button();

    this.dgvKetQua = new DataGridView();
    this.lblTrangThai = new Label();

    // cboLop
    cboLop.Location =
        new System.Drawing.Point(30,20);
    cboLop.Size =
        new System.Drawing.Size(250,25);

    // cboMonHoc
    cboMonHoc.Location =
        new System.Drawing.Point(300,20);
    cboMonHoc.Size =
        new System.Drawing.Size(250,25);

    // btnTaiDanhSach
    btnTaiDanhSach.Location =
        new System.Drawing.Point(570,20);
    btnTaiDanhSach.Size =
        new System.Drawing.Size(140,30);

    btnTaiDanhSach.Text =
        "Tải danh sách";

    btnTaiDanhSach.Click +=
        btnTaiDanhSach_Click;

    // dgvKetQua
    dgvKetQua.Location =
        new System.Drawing.Point(30,70);

    dgvKetQua.Size =
        new System.Drawing.Size(850,350);

    // btnLuuTatCa
    btnLuuTatCa.Location =
        new System.Drawing.Point(30,440);

    btnLuuTatCa.Size =
        new System.Drawing.Size(140,35);

    btnLuuTatCa.Text =
        "Lưu tất cả";

    btnLuuTatCa.Click +=
        btnLuuTatCa_Click;

    // lblTrangThai
    lblTrangThai.Location =
        new System.Drawing.Point(200,445);

    lblTrangThai.Size =
        new System.Drawing.Size(500,30);

    // Form
    this.Controls.Add(cboLop);
    this.Controls.Add(cboMonHoc);
    this.Controls.Add(btnTaiDanhSach);
    this.Controls.Add(dgvKetQua);
    this.Controls.Add(btnLuuTatCa);
    this.Controls.Add(lblTrangThai);

    this.Text = "Nhập điểm theo lớp";
    this.Load += FrmNhapDiemTheoLop_Load;

    this.ClientSize =
        new System.Drawing.Size(950,520);
}
