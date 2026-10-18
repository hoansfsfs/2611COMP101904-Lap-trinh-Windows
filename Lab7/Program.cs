using ShopManagerMini.Forms;

namespace ShopManagerMini
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            FrmLogin login = new FrmLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(
                    new FrmMain(login.CurrentUser));
            }
        }
    }
}
