using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DPFP;

namespace sistema
{
    public partial class VerificarHuellaForm : CaptureForm
    {
        private DPFP.Verification.Verification Verifier;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public string UsuarioVerificado { get; private set; }
        public bool HuellaVerificada { get; private set; }

        public VerificarHuellaForm()
        {
            InitializeComponent();
            HuellaVerificada = false;
            UsuarioVerificado = string.Empty;
        }

        protected override void Init()
        {
            base.Init();

            try
            {
                Verifier = new DPFP.Verification.Verification();
                SetPrompt("Coloque su dedo en el lector para verificar");
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
                // Verificar si el formulario sigue activo
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
                    bool verificacionExitosa = VerificarContraBaseDeDatos(features);

                    if (verificacionExitosa && !this.IsDisposed)
                    {
                        MakeReport("¡Huella verificada exitosamente!");
                        HuellaVerificada = true;

                        // Detener captura y cerrar de forma segura
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
                    MakeReport($"Error en proceso: {ex.Message}");
                }
            }
        }

        private bool VerificarContraBaseDeDatos(DPFP.FeatureSet features)
        {
            try
            {
                if (!HayHuellasRegistradas())
                {
                    SetPrompt("No hay huellas registradas en el sistema");
                    return false;
                }

                var huellasRegistradas = ObtenerHuellasDeBD();

                foreach (var huellaBD in huellasRegistradas)
                {
                    try
                    {
                        // Crear template desde los datos de la BD
                        var templateBD = new Template();
                        templateBD.DeSerialize(huellaBD.HuellaData);

                        // Verificar coincidencia
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verifier.Verify(features, templateBD, ref result);

                        if (result.Verified)
                        {
                            UsuarioVerificado = huellaBD.UsuarioNombre;
                            SetPrompt($"¡Huella verificada! Usuario: {huellaBD.UsuarioNombre}");
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MakeReport($"Error procesando huella de {huellaBD.UsuarioNombre}: {ex.Message}");
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MakeReport($"Error al verificar contra BD: {ex.Message}");
                return false;
            }
        }

        // Método auxiliar para obtener huellas de la base de datos
        private List<HuellaUsuario> ObtenerHuellasDeBD()
        {
            var huellas = new List<HuellaUsuario>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT Usuario, Huella FROM login WHERE Huella IS NOT NULL", connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            huellas.Add(new HuellaUsuario
                            {
                                UsuarioNombre = reader.GetString(0),
                                HuellaData = (byte[])reader[1]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MakeReport($"Error al obtener huellas de BD: {ex.Message}");
            }

            return huellas;
        }

        // Método para verificar si hay huellas registradas
        private bool HayHuellasRegistradas()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT COUNT(*) FROM login WHERE Huella IS NOT NULL", connection);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MakeReport($"Error al verificar huellas registradas: {ex.Message}");
                return false;
            }
        }

        // Métodos protegidos actualizados para manejo seguro de objetos desechados
        protected void SetStatus(string status)
        {
            try
            {
                if (this.IsDisposed || !this.IsHandleCreated)
                    return;

                this.BeginInvoke(new Function(delegate () {
                    if (!this.IsDisposed && StatusLine != null && !StatusLine.IsDisposed)
                        StatusLine.Text = status;
                }));
            }
            catch (ObjectDisposedException) { }
        }

        protected void SetPrompt(string prompt)
        {
            try
            {
                if (this.IsDisposed || !this.IsHandleCreated)
                    return;

                this.BeginInvoke(new Function(delegate () {
                    if (!this.IsDisposed && Prompt != null && !Prompt.IsDisposed)
                        Prompt.Text = prompt;
                }));
            }
            catch (ObjectDisposedException) { }
        }

        protected void MakeReport(string message)
        {
            try
            {
                if (this.IsDisposed || !this.IsHandleCreated)
                    return;

                this.BeginInvoke(new Function(delegate () {
                    if (!this.IsDisposed && StatusText != null && !StatusText.IsDisposed)
                        StatusText.AppendText(message + "\r\n");
                }));
            }
            catch (ObjectDisposedException) { }
        }

        protected void DrawPicture(Bitmap bitmap)
        {
            try
            {
                if (this.IsDisposed || !this.IsHandleCreated)
                    return;

                this.BeginInvoke(new Function(delegate ()
                {
                    if (this.IsDisposed || Picture.IsDisposed)
                        return;

                    if (Picture.Image != null)
                    {
                        Picture.Image.Dispose();
                        Picture.Image = null;
                    }

                    Picture.Image = new Bitmap(bitmap, Picture.Size);
                }));
            }
            catch (ObjectDisposedException)
            {
                // Ignorar si el formulario ya está desechado
            }
            catch (InvalidOperationException)
            {
                // Ignorar si el handle no está creado
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                Stop(); // Detener la captura primero

                if (!this.IsDisposed && this.IsHandleCreated)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (ObjectDisposedException)
            {
                // El formulario ya está cerrado, no hacer nada
            }
        }

        // Sobrescribir el método OnFormClosed para mayor seguridad
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                Stop(); // Asegurarse de detener la captura
            }
            catch (Exception)
            {
                // Ignorar excepciones al cerrar
            }
            base.OnFormClosed(e);
        }
    }

    // Clase para representar los datos de huella
    public class HuellaUsuario
    {
        public string UsuarioNombre { get; set; }
        public byte[] HuellaData { get; set; }
    }
}