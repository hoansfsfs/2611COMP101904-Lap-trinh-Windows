using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmLogin : Form
    {
        public User CurrentUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(
            object sender,
            EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if(string.IsNullOrWhiteSpace(user) ||
               string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }

            if(user == "admin" && pass == "123")
            {
                CurrentUser = new User
                {
                    Username = "admin",
                    FullName = "Quản trị viên",
                    Role = "Admin"
                };

                DialogResult = DialogResult.OK;
            }
            else if(user == "user" && pass == "123")
            {
                CurrentUser = new User
                {
                    Username = "user",
                    FullName = "Nhân viên bán hàng",
                    Role = "User"
                };

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(
                    "Sai tài khoản hoặc mật khẩu");
            }
        }

        private void btnExit_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }
    }
}
