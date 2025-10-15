using sistema.Reports;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace sistema.Expediente
{
    public partial class frmExpediente
    {
        public void ExportarExpedienteAPdf()
        {
            if (PacienteID <= 0)
            {
                MessageBox.Show("Paciente inválido.");
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Expediente_{PacienteID}.pdf"
            })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var cs = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
                        PdfExporter.ExportExpedientePaciente(PacienteID, cs, sfd.FileName);
                        MessageBox.Show("PDF generado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar PDF: " + ex.Message);
                    }
                }
            }
        }
    }
}