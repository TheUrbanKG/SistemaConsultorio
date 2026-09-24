using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DPFP;

namespace sistema
{
    public partial class VerificarHuellaPaciente : CaptureForm
    {
        private DPFP.Verification.Verification Verifier;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public string PacienteEncontrado { get; private set; }
        public int PacienteID { get; private set; }
        public string CedulaPaciente { get; private set; }
        public bool HuellaVerificada { get; private set; }

        public VerificarHuellaPaciente()
        {
            InitializeComponent();
            HuellaVerificada = false;
            PacienteEncontrado = string.Empty;
            PacienteID = -1;
            CedulaPaciente = string.Empty;
        }

        protected override void Init()
        {
            base.Init();

            try
            {
                Verifier = new DPFP.Verification.Verification();
                SetPrompt("Coloque su dedo en el lector para buscar paciente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando verificador: {ex.Message}");
            }
        }

        protected override void Process(DPFP.Sample Sample)
        {
            try
            {
                if (this.IsDisposed || !this.IsHandleCreated)
                    return;

                // Dibujar la imagen de la huella
                var bitmap = ConvertSampleToBitmap(Sample);
                if (bitmap != null)
                {
                    DrawPicture(bitmap);
                }

                // Procesar la muestra
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                if (features != null && !this.IsDisposed)
                {
                    bool verificacionExitosa = VerificarContraPacientes(features);

                    if (verificacionExitosa && !this.IsDisposed)
                    {
                        MakeReport("¡Paciente encontrado por huella!");
                        HuellaVerificada = true;

                        Stop();

                        this.BeginInvoke(new Action(() =>
                        {
                            if (!this.IsDisposed)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }));
                    }
                    else
                    {
                        MakeReport("Paciente no encontrado. Intente nuevamente.");
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // Ignorar - el formulario ya se está cerrando
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    MakeReport($"Error en búsqueda: {ex.Message}");
                }
            }
        }

        private bool VerificarContraPacientes(DPFP.FeatureSet features)
        {
            try
            {
                if (!HayPacientesConHuella())
                {
                    SetPrompt("No hay pacientes con huella registrada");
                    return false;
                }

                var pacientesConHuella = ObtenerPacientesConHuella();

                foreach (var paciente in pacientesConHuella)
                {
                    try
                    {
                        var templateBD = new Template();
                        templateBD.DeSerialize(paciente.HuellaData);

                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verifier.Verify(features, templateBD, ref result);

                        if (result.Verified)
                        {
                            PacienteEncontrado = $"{paciente.Nombre} {paciente.Apellido}";
                            PacienteID = paciente.PacienteID;
                            CedulaPaciente = paciente.Cedula;
                            SetPrompt($"¡Paciente encontrado! {PacienteEncontrado}");
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MakeReport($"Error procesando huella de {paciente.Nombre}: {ex.Message}");
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MakeReport($"Error al buscar pacientes: {ex.Message}");
                return false;
            }
        }

        private List<PacienteConHuella> ObtenerPacientesConHuella()
        {
            var pacientes = new List<PacienteConHuella>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(@"
SELECT 
    PacienteID, 
    Nombre, 
    Apellido, 
    Cedula,
    Huella 
FROM Paciente 
WHERE Huella IS NOT NULL", connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pacientes.Add(new PacienteConHuella
                            {
                                PacienteID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Cedula = reader.GetString(3),
                                HuellaData = (byte[])reader[4]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MakeReport($"Error al obtener pacientes: {ex.Message}");
            }

            return pacientes;
        }

        private bool HayPacientesConHuella()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT COUNT(*) FROM Paciente WHERE Huella IS NOT NULL", connection);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MakeReport($"Error al verificar pacientes: {ex.Message}");
                return false;
            }
        }

        // ... (los métodos SetStatus, SetPrompt, MakeReport, DrawPicture, etc. los copias iguales)

        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                Stop();
                if (!this.IsDisposed && this.IsHandleCreated)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (ObjectDisposedException) { }
        }
    }

    public class PacienteConHuella
    {
        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public byte[] HuellaData { get; set; }
    }
}