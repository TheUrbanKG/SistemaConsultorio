using System;
using System.Windows.Forms;

namespace sistema
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var login = new Login())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
        }
    }
}