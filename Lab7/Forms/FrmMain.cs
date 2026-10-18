using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmMain : Form
    {
        private User currentUser;

        public FrmMain(User user)
        {
            InitializeComponent();

            currentUser = user;
        }

        private void FrmMain_Load(
            object sender,
            EventArgs e)
        {
            IsMdiContainer = true;

            lblUser.Text =
                currentUser.FullName;

            lblRole.Text =
                currentUser.Role;
        }

        private void OpenChild<T>()
            where T : Form,new()
        {
            foreach(Form frm in MdiChildren)
            {
                if(frm is T)
                {
                    frm.Activate();
                    return;
                }
            }

            T child = new T();

            child.MdiParent = this;

            child.Show();
        }

        private void mnuProduct_Click(
            object sender,
            EventArgs e)
        {
            OpenChild<FrmProduct>();
        }

        private void mnuCustomer_Click(
            object sender,
            EventArgs e)
        {
            OpenChild<FrmCustomer>();
        }

        private void mnuAbout_Click(
            object sender,
            EventArgs e)
        {
            OpenChild<FrmAbout>();
        }

        private void mnuExit_Click(
            object sender,
            EventArgs e)
        {
            DialogResult rs =
                MessageBox.Show(
                    "Thoát chương trình?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
                Application.Exit();
        }
    }
}
