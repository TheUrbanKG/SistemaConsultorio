using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema.Main.Pacientes
{
    public partial class CapturarHuella : CaptureForm
    {
        public delegate void OnTemplateEventHandler(DPFP.Template template);

        public event OnTemplateEventHandler OnTemplate;

        private DPFP.Processing.Enrollment Enroller;
        private bool fingerprintAvailable = true; // indica si la librería/lector está disponible

        protected override void Init()
        {
            base.Init();
            base.Text = "Captura de Huella";

            try
            {
                Enroller = new DPFP.Processing.Enrollment(); // Create an enrollment.
                fingerprintAvailable = true;
            }
            catch (DllNotFoundException ex)
            {
                fingerprintAvailable = false;
                MakeReport("Lector de huellas no disponible ( DLL nativa no encontrada ).");
                SetPrompt("Lector desconectado. Comprueba conexión/instalación.");
                Stop();
                // opcional: loggear ex.Message si hay un logger
            }
            catch (BadImageFormatException ex)
            {
                fingerprintAvailable = false;
                MakeReport("Error al cargar la librería del lector (formato inválido).");
                SetPrompt("Lector con librería inválida. Reinstala controladores.");
                Stop();
            }
            catch (Exception ex)
            {
                fingerprintAvailable = false;
                MakeReport("Error al inicializar lector de huellas: " + ex.Message);
                SetPrompt("Lector no disponible.");
                Stop();
            }

            UpdateStatus();
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            if (!fingerprintAvailable)
            {
                // Evitar procesar si no hay librería/lector
                return;
            }

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            // Check quality of the sample and add to enroller if it's good
            if (features != null)
            {
                try
                {
                    MakeReport("La muestra de la Huella Digital ha sido creada.");
                    Enroller.AddFeatures(features);     // Add feature set to template.
                }
                catch (DllNotFoundException ex)
                {
                    // Si ocurre una DLL faltante en tiempo de ejecución por alguna llamada interna
                    fingerprintAvailable = false;
                    MakeReport("Lector de huellas dejó de estar disponible.");
                    SetPrompt("Lector desconectado.");
                    Stop();
                    OnTemplate?.Invoke(null);
                    return;
                }
                catch (BadImageFormatException)
                {
                    fingerprintAvailable = false;
                    MakeReport("Error de formato en la librería del lector.");
                    SetPrompt("Lector no funcional.");
                    Stop();
                    OnTemplate?.Invoke(null);
                    return;
                }
                catch (Exception)
                {
                    // continuar al finally para manejar estado del enroller
                }
                finally
                {
                    UpdateStatus();

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                            OnTemplate?.Invoke(Enroller.Template);
                            SetPrompt("Click Close, and then click Fingerprint Verification.");
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate?.Invoke(null);
                            Start();
                            break;
                    }
                }
            }
        }

        private void UpdateStatus()
        {
            if (!fingerprintAvailable)
            {
                SetStatus("Lector de huellas no disponible.");
                return;
            }

            try
            {
                // Show number of samples needed.
                SetStatus(string.Format("Muestra de Huellas necesarias: {0}", Enroller.FeaturesNeeded));
            }
            catch (Exception)
            {
                // Si algo falla al consultar Enroller (por seguridad), marcar no disponible.
                fingerprintAvailable = false;
                SetStatus("Lector de huellas no disponible.");
            }
        }

        public CapturarHuella()
        {
            InitializeComponent();
        }
    }
}
