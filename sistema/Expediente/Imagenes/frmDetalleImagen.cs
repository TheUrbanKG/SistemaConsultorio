using MetroFramework.Forms;
using sistema.Data;
using sistema.Infrastructure.Security;
using sistema.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace sistema.Expediente.Imagenes
{
    public partial class frmDetalleImagen : MetroForm
    {
        private readonly int _pacienteId;
        private readonly ImagenPacienteRepository _repo = new ImagenPacienteRepository();

        private Image _imagenCargada;
        private string _formatoOriginal = "JPG";
        private int _tamanoBytes = 0;

        public frmDetalleImagen(int pacienteId)
        {
            InitializeComponent();
            _pacienteId = pacienteId;
            cbCategoria.SelectedIndex = 0;
            dtFecha.Value = DateTime.Today;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar Imagen Médica";
                ofd.Filter = "Imágenes Clínicas (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos (*.*)|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    CargarArchivoImagen(ofd.FileName);
                }
            }
        }

        private void CargarArchivoImagen(string rutaArchivo)
        {
            try
            {
                var fi = new FileInfo(rutaArchivo);
                if (fi.Length > 25 * 1024 * 1024) // 25 MB max
                {
                    MessageBox.Show("La imagen seleccionada supera el límite recomendado de 25MB.", "Archivo demasiado grande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _tamanoBytes = (int)fi.Length;
                _formatoOriginal = fi.Extension.TrimStart('.').ToUpperInvariant();
                if (string.IsNullOrWhiteSpace(_formatoOriginal)) _formatoOriginal = "JPG";

                // Cargar imagen en memoria sin bloquear el archivo original
                byte[] bytesArchivo = File.ReadAllBytes(rutaArchivo);
                using (var ms = new MemoryStream(bytesArchivo))
                {
                    using (var imgTemp = Image.FromStream(ms))
                    {
                        if (_imagenCargada != null)
                        {
                            _imagenCargada.Dispose();
                        }
                        _imagenCargada = new Bitmap(imgTemp);
                    }
                }

                pbPreview.Image = _imagenCargada;
                pbPreview.Visible = true;
                lblDropHint.Visible = false;

                // Si el título está vacío, sugerir el nombre del archivo
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                    txtTitulo.Text = Path.GetFileNameWithoutExtension(fi.Name);
                }

                double tamanoKB = _tamanoBytes / 1024.0;
                lblInfoArchivo.Text = $"Archivo: {fi.Name} ({tamanoKB:F1} KB, {_imagenCargada.Width}x{_imagenCargada.Height} px)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen seleccionada: " + ex.Message, "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlPreview_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pnlPreview_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    CargarArchivoImagen(files[0]);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_imagenCargada == null)
            {
                MessageBox.Show("Debes seleccionar o arrastrar una imagen primero.", "Imagen requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSeleccionar.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor ingresa un título descriptivo para la imagen.", "Título requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Formato de compresión
                ImageFormat fmt = ImageFormat.Jpeg;
                if (_formatoOriginal == "PNG") fmt = ImageFormat.Png;

                byte[] imagenCompletaBytes = ImagenPaciente.ImageToByteArray(_imagenCargada, fmt);
                byte[] miniaturaBytes = ImagenPaciente.GenerarMiniaturaBytes(_imagenCargada, 250, 250);

                var nuevaImg = new ImagenPaciente
                {
                    PacienteID = _pacienteId,
                    Titulo = txtTitulo.Text.Trim(),
                    Categoria = cbCategoria.SelectedItem?.ToString() ?? "Otro",
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
                    FechaTomada = dtFecha.Value,
                    Formato = _formatoOriginal,
                    TamanoBytes = imagenCompletaBytes.Length,
                    ImagenData = imagenCompletaBytes,
                    MiniaturaData = miniaturaBytes,
                    UsuarioID = null
                };

                int nuevoId = _repo.Insertar(nuevaImg);

                if (nuevoId > 0)
                {
                    MessageBox.Show("Imagen guardada exitosamente en el expediente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la imagen en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_imagenCargada != null)
            {
                _imagenCargada.Dispose();
                _imagenCargada = null;
            }
        }
    }
}
