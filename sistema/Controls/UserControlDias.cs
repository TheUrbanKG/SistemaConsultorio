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
    public partial class UserControlDias : UserControl
    {
        public UserControlDias()
        {
            InitializeComponent();
        }

        private void UserControlDias_Load(object sender, EventArgs e)
        {

        }

        public void dias(int numDias)
        {
            lblDias.Text = numDias + ""; 
        }

        private void UserControlDias_Click(object sender, EventArgs e)
        {
            AgregarCitas agregarCitas = new AgregarCitas();
            agregarCitas.ShowDialog();
        }

        private void lblDias_Click(object sender, EventArgs e)
        {
            AgregarCitas agregarCitas = new AgregarCitas();
            agregarCitas.ShowDialog();
        }
    }
}
