using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmCitas : Form
    {
        int mes, año;
        public frmCitas()
        {
            InitializeComponent();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            displaDays();
        }

        private void displaDays()
        {
            DateTime now = DateTime.Now;
            mes = now.Month;
            año = now.Year;

            string mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            labelFecha.Text = mesNombre + " " + año;

            DateTime inicioDelMes = new DateTime(año,mes,1);
            int dias = DateTime.DaysInMonth(año, mes);

            int diasSemana = Convert.ToInt32(inicioDelMes.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < diasSemana; i++) 
            {
                UserControlBlank ucbBlank = new UserControlBlank();
                contenedorDias.Controls.Add(ucbBlank);
            }

            for (int i = 1; i <= dias; i++) 
            {
                UserControlDias ucdias = new UserControlDias();
                ucdias.dias(i);
                contenedorDias.Controls.Add(ucdias);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            contenedorDias.Controls.Clear();
            mes++;
            if (mes > 12)
            {
                mes = 1;
                año++;
            }

            GenerarCalendario();
        }

        private void labelFecha_Click(object sender, EventArgs e)
        {
            
        }

        private void contenedorDias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GenerarCalendario()
        {
            contenedorDias.Controls.Clear();

            string mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            labelFecha.Text = mesNombre + " " + año;

            DateTime inicioDelMes = new DateTime(año, mes, 1);
            int dias = DateTime.DaysInMonth(año, mes);
            int diasSemana = (int)inicioDelMes.DayOfWeek;

            for (int i = 0; i < diasSemana; i++)
            {
                contenedorDias.Controls.Add(new UserControlBlank());
            }

            for (int i = 1; i <= dias; i++)
            {
                UserControlDias ucdias = new UserControlDias();
                ucdias.dias(i);
                contenedorDias.Controls.Add(ucdias);
            }
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            contenedorDias.Controls.Clear();
            mes--;

            if (mes < 1)
            {
                mes = 12;
                año--;
            }

            GenerarCalendario();
        }
    }
}
