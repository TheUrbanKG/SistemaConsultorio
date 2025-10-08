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
using System.Configuration;

namespace sistema
{
    public partial class frmCuentas : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public frmCuentas()
        {
            InitializeComponent();
        }

        public void CargarUsuarios()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                Usuario, 
                Nombre, 
                Apellido, 
                Rol, 
                Status
            FROM login";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvUsuarios.Rows.Add(
                        row["Usuario"],
                        row["Nombre"],
                        row["Apellido"],
                        row["Rol"],
                        row["Status"]
                    );
                }
            }
        }

        private void frmCuentas_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAñadirUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
