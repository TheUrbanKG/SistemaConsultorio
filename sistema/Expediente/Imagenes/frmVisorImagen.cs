using sistema.Data;
using sistema.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace sistema.Expediente.Imagenes
{
    public partial class frmVisorImagen : Form
    {
        private readonly int _imagenId;
        private readonly ImagenPacienteRepository _repo = new ImagenPacienteRepository();

        private ImagenPaciente _imagenActual;
        private Image _imagenOriginal;
        private float _zoomFactor = 1.0f;
        private bool _modoAjustado = true;

        public frmVisorImagen(int imagenId)
        {
            InitializeComponent();
            _imagenId = imagenId;

            // Habilitar zoom con la rueda del ratón sobre el canvas
            pnlCanvas.MouseWheel += PnlCanvas_MouseWheel;
            pbVisor.MouseWheel += PnlCanvas_MouseWheel;
        }

        private void frmVisorImagen_Load(object sender, EventArgs e)
        {
            CargarDatosImagen();
        }

        private void CargarDatosImagen()
        {
            try
            {
                _imagenActual = _repo.ObtenerPorId(_imagenId);
                if (_imagenActual == null)
                {
                    MessageBox.Show("No se encontró la imagen solicitada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // Cargar datos en el panel lateral
                lblTituloDetalle.Text = _imagenActual.Titulo;
                lblTituloVisor.Text = "Visor Clínico — " + _imagenActual.Titulo;
                lblCategoria.Text = _imagenActual.Categoria.ToUpper();
                lblFecha.Text = "Fecha de toma: " + _imagenActual.FechaTomada.ToString("dd/MM/yyyy");

                if (!string.IsNullOrWhiteSpace(_imagenActual.Descripcion))
                    lblNotasDetalle.Text = _imagenActual.Descripcion;
                else
                    lblNotasDetalle.Text = "Sin observaciones registradas.";

                // Cargar imagen en alta resolución
                if (_imagenActual.ImagenData != null && _imagenActual.ImagenData.Length > 0)
                {
                    _imagenOriginal = ImagenPaciente.ByteArrayToImage(_imagenActual.ImagenData);
                    pbVisor.Image = _imagenOriginal;

                    double kb = _imagenActual.TamanoBytes / 1024.0;
                    lblDimensiones.Text = $"Resolución: {_imagenOriginal.Width} × {_imagenOriginal.Height} px\nTamaño: {kb:F1} KB ({_imagenActual.Formato})";
                }
                else if (_imagenActual.MiniaturaData != null)
                {
                    _imagenOriginal = ImagenPaciente.ByteArrayToImage(_imagenActual.MiniaturaData);
                    pbVisor.Image = _imagenOriginal;
                    lblDimensiones.Text = "Resolución: (Miniatura disponible)";
                }

                AjustarImagen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustarImagen()
        {
            _modoAjustado = true;
            _zoomFactor = 1.0f;
            pbVisor.Dock = DockStyle.Fill;
            pbVisor.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void AplicarZoom(float delta)
        {
            if (_imagenOriginal == null) return;

            if (_modoAjustado)
            {
                _modoAjustado = false;
                pbVisor.Dock = DockStyle.None;
                pbVisor.SizeMode = PictureBoxSizeMode.StretchImage;

                // Calcular tamaño base a partir del tamaño actual visible
                float ratio = Math.Min((float)pnlCanvas.Width / _imagenOriginal.Width, (float)pnlCanvas.Height / _imagenOriginal.Height);
                _zoomFactor = ratio > 0 ? ratio : 1.0f;
            }

            _zoomFactor += delta;
            if (_zoomFactor < 0.1f) _zoomFactor = 0.1f;
            if (_zoomFactor > 5.0f) _zoomFactor = 5.0f;

            int nuevoAncho = (int)(_imagenOriginal.Width * _zoomFactor);
            int nuevoAlto = (int)(_imagenOriginal.Height * _zoomFactor);

            pbVisor.Size = new Size(nuevoAncho, nuevoAlto);

            // Centrar si es menor que el contenedor
            int posX = Math.Max(0, (pnlCanvas.Width - nuevoAncho) / 2);
            int posY = Math.Max(0, (pnlCanvas.Height - nuevoAlto) / 2);
            pbVisor.Location = new Point(posX, posY);
        }

        private void PnlCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                AplicarZoom(0.15f);
            else if (e.Delta < 0)
                AplicarZoom(-0.15f);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            AplicarZoom(0.25f);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            AplicarZoom(-0.25f);
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            AjustarImagen();
        }

        private void btnRotar_Click(object sender, EventArgs e)
        {
            if (_imagenOriginal == null) return;

            _imagenOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbVisor.Image = _imagenOriginal;
            if (_modoAjustado)
            {
                AjustarImagen();
            }
            else
            {
                AplicarZoom(0);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_imagenOriginal == null) return;

            using (var sfd = new SaveFileDialog())
            {
                string nombreLimpio = string.Join("_", (_imagenActual.Titulo ?? "ImagenClinica").Split(Path.GetInvalidFileNameChars()));
                sfd.FileName = $"{nombreLimpio}_{_imagenActual.FechaTomada:yyyyMMdd}";
                sfd.Filter = "Imagen JPEG (*.jpg)|*.jpg|Imagen PNG (*.png)|*.png|Todos los archivos (*.*)|*.*";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var fmt = sfd.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                            ? ImageFormat.Png
                            : ImageFormat.Jpeg;

                        _imagenOriginal.Save(sfd.FileName, fmt);
                        MessageBox.Show("Imagen descargada exitosamente.", "Descarga completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo guardar la imagen en disco: " + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_imagenOriginal != null)
            {
                _imagenOriginal.Dispose();
                _imagenOriginal = null;
            }
        }
    }
}
