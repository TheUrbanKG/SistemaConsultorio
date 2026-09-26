using sistema.Data;
using sistema.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sistema.Expediente.Imagenes
{
    public partial class frmImagenesPaciente : Form
    {
        private readonly ImagenPacienteRepository _repo = new ImagenPacienteRepository();

        public int PacienteID { get; set; }

        public frmImagenesPaciente()
        {
            InitializeComponent();
        }

        private void frmImagenesPaciente_Load(object sender, EventArgs e)
        {
            if (cbFiltroCategoria.SelectedIndex < 0)
                cbFiltroCategoria.SelectedIndex = 0;

            if (PacienteID > 0)
            {
                CargarImagenes();
            }
            else
            {
                MostrarEstadoVacio(true, "No se ha seleccionado un paciente válido");
            }
        }

        public void CargarImagenes()
        {
            string categoria = cbFiltroCategoria.SelectedItem?.ToString();
            if (categoria == "Todas las categorías") categoria = "Todas";

            try
            {
                var imagenes = _repo.ObtenerPorPaciente(PacienteID, categoria);
                MostrarImagenes(imagenes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las imágenes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstadoVacio(bool visible, string mensaje = "No hay imágenes registradas para este paciente")
        {
            lblSinImagenes.Text = mensaje;
            lblSinImagenes.Visible = visible;
            pbSinImagenes.Visible = visible;
            flpImagenes.Visible = !visible;
        }

        private void MostrarImagenes(List<ImagenPaciente> imagenes)
        {
            // Limpia controles previos liberando recursos de imágenes
            foreach (Control c in flpImagenes.Controls)
            {
                c.Dispose();
            }
            flpImagenes.Controls.Clear();

            lblTotalImagenes.Text = $"Total: {imagenes.Count} {(imagenes.Count == 1 ? "imagen" : "imágenes")}";

            if (imagenes.Count == 0)
            {
                MostrarEstadoVacio(true);
                return;
            }

            MostrarEstadoVacio(false);

            foreach (var img in imagenes)
            {
                var card = CrearTarjetaImagen(img);
                flpImagenes.Controls.Add(card);
            }
        }

        private Panel CrearTarjetaImagen(ImagenPaciente img)
        {
            var card = new Panel
            {
                Width = 250,
                Height = 310,
                BackColor = Color.White,
                Margin = new Padding(10),
                Cursor = Cursors.Default
            };

            // Determinar color de acento según la categoría
            Color colorCategoria;
            switch (img.Categoria)
            {
                case "Evolución":
                    colorCategoria = Color.FromArgb(37, 99, 235); // Blue
                    break;
                case "Rayos X":
                    colorCategoria = Color.FromArgb(124, 58, 237); // Purple
                    break;
                case "Ecografía":
                    colorCategoria = Color.FromArgb(5, 150, 105); // Emerald
                    break;
                case "Laboratorio":
                    colorCategoria = Color.FromArgb(217, 119, 6); // Amber
                    break;
                default:
                    colorCategoria = Color.FromArgb(100, 116, 139); // Slate
                    break;
            }

            // Borde superior de color por categoría
            var pnlTopLine = new Panel
            {
                Height = 4,
                Dock = DockStyle.Top,
                BackColor = colorCategoria
            };
            card.Controls.Add(pnlTopLine);

            // Badge de categoría
            var lblBadge = new Label
            {
                Text = img.Categoria.ToUpper(),
                Font = new Font("Century Gothic", 7.5f, FontStyle.Bold),
                ForeColor = colorCategoria,
                BackColor = Color.FromArgb(241, 245, 249),
                Location = new Point(10, 10),
                AutoSize = true,
                Padding = new Padding(4, 2, 4, 2)
            };
            card.Controls.Add(lblBadge);

            // Etiqueta de fecha
            var lblFecha = new Label
            {
                Text = img.FechaTomada.ToString("dd/MM/yyyy"),
                Font = new Font("Century Gothic", 8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(140, 12),
                AutoSize = true
            };
            card.Controls.Add(lblFecha);

            // PictureBox con la miniatura
            var pbThumb = new PictureBox
            {
                Location = new Point(10, 35),
                Size = new Size(230, 170),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(248, 250, 252),
                Cursor = Cursors.Hand
            };

            if (img.MiniaturaData != null && img.MiniaturaData.Length > 0)
            {
                pbThumb.Image = ImagenPaciente.ByteArrayToImage(img.MiniaturaData);
            }

            // Al hacer clic en la foto, se abre el visor a pantalla completa
            pbThumb.Click += (s, e) => AbrirVisor(img.Id);
            card.Controls.Add(pbThumb);

            // Título de la imagen
            var lblTitulo = new Label
            {
                Text = img.Titulo,
                Font = new Font("Century Gothic", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(10, 212),
                Size = new Size(230, 36),
                AutoEllipsis = true
            };
            card.Controls.Add(lblTitulo);

            // Panel de botones de acción
            var pnlAcciones = new Panel
            {
                Location = new Point(10, 256),
                Size = new Size(230, 40)
            };

            // Botón Ver
            var btnVer = new Button
            {
                Text = "Ver Detalle",
                Font = new Font("Century Gothic", 8.5f, FontStyle.Bold),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(0, 4),
                Size = new Size(130, 32),
                Cursor = Cursors.Hand
            };
            btnVer.FlatAppearance.BorderSize = 0;
            btnVer.Click += (s, e) => AbrirVisor(img.Id);
            pnlAcciones.Controls.Add(btnVer);

            // Botón Eliminar
            var btnEliminar = new Button
            {
                Text = "Eliminar",
                Font = new Font("Century Gothic", 8.5f, FontStyle.Bold),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(138, 4),
                Size = new Size(92, 32),
                Cursor = Cursors.Hand
            };
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Click += (s, e) => EliminarImagen(img.Id, img.Titulo);
            pnlAcciones.Controls.Add(btnEliminar);

            card.Controls.Add(pnlAcciones);

            // Dibujar borde sutil alrededor de la tarjeta
            card.Paint += (s, pe) =>
            {
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    pe.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            return card;
        }

        private void AbrirVisor(int imagenId)
        {
            var visor = new frmVisorImagen(imagenId);
            visor.ShowDialog(this);
        }

        private void EliminarImagen(int imagenId, string titulo)
        {
            var r = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar permanentemente la imagen '{titulo}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                try
                {
                    if (_repo.Eliminar(imagenId))
                    {
                        CargarImagenes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PacienteID > 0)
            {
                CargarImagenes();
            }
        }

        private void btnNuevaImagen_Click(object sender, EventArgs e)
        {
            var frmDetalle = new frmDetalleImagen(this.PacienteID);
            if (frmDetalle.ShowDialog(this) == DialogResult.OK)
            {
                CargarImagenes();
            }
        }
    }
}
