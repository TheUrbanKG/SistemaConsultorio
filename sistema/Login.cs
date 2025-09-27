using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=DESKTOP-GR08655; database=tesis; integrated security=true");


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            conexion.Open();

            string consulta = "select * from login where usuario='" + cajaUsuario.Text + "' and contraseña='" + cajaContrasena.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                frmMain frmMain = new frmMain();
                this.Hide();
                frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contrase�a incorrectos");
            }
        }
    }
}
