using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class UserControlDias : UserControl
    {
        public DateTime Fecha { get; set; }

        public UserControlDias()
        {
            InitializeComponent();
            // ELIMINAR esta línea: lblDias.Click += UserControlDias_Click;
        }

        private void UserControlDias_Load(object sender, EventArgs e)
        {
            // Vacío
        }

        public void dias(int numDias)
        {
            lblDias.Text = numDias + "";
        }

        private void UserControlDias_Click(object sender, EventArgs e)
        {
            // Verifica si ya hay una instancia abierta de AgregarCitas
            var existente = Application.OpenForms.OfType<AgregarCitas>().FirstOrDefault();
            if (existente != null)
            {
                existente.BringToFront();
                return;
            }

            // Crear nueva instancia si no existe
            AgregarCitas agregarCitas = new AgregarCitas(this.Fecha);
            agregarCitas.Show();
        }
    }
}