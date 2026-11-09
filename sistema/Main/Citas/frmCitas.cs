using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmCitas : Form
    {
        public DateTime FechaSeleccionada { get; set; }
        private int mes, año;

        public frmCitas()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.UserPaint, true);
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mes = now.Month;
            año = now.Year;

            GenerarCalendario();
            CentrarPanelPrincipal();
        }

        private void frmCitas_Resize(object sender, EventArgs e)
        {
            CentrarPanelPrincipal();
        }

        private void CentrarPanelPrincipal()
        {
            if (panel1 != null && this.ClientSize.Width > panel1.Width + 32)
            {
                panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            }
            else if (panel1 != null)
            {
                panel1.Left = 16;
            }
        }

        /// <summary>
        /// Obtiene un diccionario con el total de citas por fecha para el mes y año indicados.
        /// </summary>
        private Dictionary<DateTime, int> ObtenerCitasDelMes(int targetAño, int targetMes)
        {
            var resultado = new Dictionary<DateTime, int>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBContext"]?.ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                    return resultado;

                DateTime inicioMes = new DateTime(targetAño, targetMes, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT CAST(FechaCita AS DATE) AS Fecha, COUNT(*) AS Total
                        FROM Cita
                        WHERE FechaCita >= @Inicio AND FechaCita <= @Fin
                        GROUP BY CAST(FechaCita AS DATE);";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Inicio", inicioMes.Date);
                        cmd.Parameters.AddWithValue("@Fin", finMes.Date);
                        conexion.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Fecha"] != DBNull.Value && reader["Total"] != DBNull.Value)
                                {
                                    DateTime fecha = Convert.ToDateTime(reader["Fecha"]).Date;
                                    int total = Convert.ToInt32(reader["Total"]);
                                    resultado[fecha] = total;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo silencioso para no interrumpir la visualización del calendario
                System.Diagnostics.Debug.WriteLine("Error al consultar citas del mes: " + ex.Message);
            }

            return resultado;
        }

        /// <summary>
        /// Genera y dibuja los controles del calendario para el mes y año activos.
        /// </summary>
        private void GenerarCalendario()
        {
            contenedorDias.SuspendLayout();
            contenedorDias.Controls.Clear();

            // Formatear mes y año con la primera letra en mayúscula
            string mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            mesNombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mesNombre);
            labelFecha.Text = $"{mesNombre} {año}";

            // Obtener citas programadas de este mes
            var citasPorDia = ObtenerCitasDelMes(año, mes);

            DateTime inicioDelMes = new DateTime(año, mes, 1);
            int diasEnMes = DateTime.DaysInMonth(año, mes);
            int diasSemana = (int)inicioDelMes.DayOfWeek; // 0 = Domingo, 1 = Lunes, etc.

            // Agregar casillas en blanco para los días anteriores al inicio del mes
            for (int i = 0; i < diasSemana; i++)
            {
                contenedorDias.Controls.Add(new UserControlBlank());
            }

            // Agregar casillas de cada día del mes
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                DateTime fechaDia = new DateTime(año, mes, dia);
                int cantidadCitas = citasPorDia.ContainsKey(fechaDia.Date) ? citasPorDia[fechaDia.Date] : 0;

                UserControlDias ucdias = new UserControlDias();
                ucdias.SetDia(fechaDia, cantidadCitas);

                // Callback cuando se registre o edite una cita para actualizar el calendario
                ucdias.CitaAgendadaCallback = () => GenerarCalendario();

                contenedorDias.Controls.Add(ucdias);
            }

            contenedorDias.ResumeLayout();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            mes--;
            if (mes < 1)
            {
                mes = 12;
                año--;
            }
            GenerarCalendario();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            mes++;
            if (mes > 12)
            {
                mes = 1;
                año++;
            }
            GenerarCalendario();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mes = now.Month;
            año = now.Year;
            GenerarCalendario();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, panel1.Width - 1, panel1.Height - 1);
            }
        }

        private void panelLeyenda_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.FromArgb(187, 247, 208), 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, panelLeyenda.Width - 1, panelLeyenda.Height - 1);
            }
        }

        private void panelDotLeyenda_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush b = new SolidBrush(Color.FromArgb(0, 168, 89)))
            {
                e.Graphics.FillEllipse(b, 0, 0, panelDotLeyenda.Width - 1, panelDotLeyenda.Height - 1);
            }
        }
    }
}
