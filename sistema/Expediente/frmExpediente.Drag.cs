using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace sistema.Expediente
{
    public partial class frmExpediente
    {
        // WinAPI para simular arrastre de la barra de título
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Nos aseguramos de enganchar el evento cuando el handle esté creado
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (sataPanel1 != null)
            {
                // Evita múltiples suscripciones si el control se recrea
                sataPanel1.MouseDown -= SataPanel1_MouseDown;
                sataPanel1.MouseDown += SataPanel1_MouseDown;
            }
        }

        private void SataPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}