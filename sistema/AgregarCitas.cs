using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class AgregarCitas : Form
    {
        public AgregarCitas()
        {
            InitializeComponent();
        }

        private void AgregarCitas_Load(object sender, EventArgs e)
        {
            lblFecha.ForeColor = Color.DarkSlateGray;

            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm:ss");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PacienteCita pacienteCita = new PacienteCita();
            pacienteCita.ShowDialog();
        }
    }
}
