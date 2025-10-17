using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace sistema.Expediente.Recetas
{
    public partial class frmDetalleRecetas : MetroFramework.Forms.MetroForm
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int PacienteID { get; set; }
        public int? RecetaID { get; set; } // Id en PlanTerapeutico

        private int articuloIndex = 0;

        public frmDetalleRecetas()
        {
            InitializeComponent();

            this.Load += frmDetalleRecetas_Load;
            btnAgregarArticulo.Click += (s,e) => AgregarFilaArticulo();
            btnGuardar.Click += btnGuardar_Click;

            // Asegura layout vertical y scroll
            flpArticulos.WrapContents = false;
            flpArticulos.FlowDirection = FlowDirection.TopDown;
            flpArticulos.AutoScroll = true;

            // Reajusta el ancho de filas y separadores cuando cambie el tamaño del contenedor
            flpArticulos.SizeChanged += (s, e) =>
            {
                foreach (Control c in flpArticulos.Controls)
                {
                    if (c is Panel p && (p.Tag as string) == "filaArticulo")
                        AjustarAnchoFila(p);
                    else if ((c.Tag as string) == "separator")
                        AjustarAnchoControl(c);
                }
            };
        }

        // Calcula el ancho disponible para un Panel fila
        private void AjustarAnchoFila(Panel fila)
        {
            var disponible = flpArticulos.ClientSize.Width
                             - flpArticulos.Padding.Left - flpArticulos.Padding.Right
                             - fila.Margin.Left - fila.Margin.Right;

            fila.Width = Math.Max(disponible, 100);
        }

        // Calcula el ancho disponible para cualquier control (ej. separador)
        private void AjustarAnchoControl(Control control)
        {
            var disponible = flpArticulos.ClientSize.Width
                             - flpArticulos.Padding.Left - flpArticulos.Padding.Right
                             - control.Margin.Left - control.Margin.Right;

            control.Width = Math.Max(disponible, 20);
        }

        private void frmDetalleRecetas_Load(object sender, EventArgs e)
        {
            CargarCuadrosClinicos();

            if (RecetaID.HasValue)
            {
                CargarPlan(RecetaID.Value);
                CargarArticulos(RecetaID.Value);
            }
            else
            {
                if (flpArticulos.Controls.Count == 0)
                    AgregarFilaArticulo();
            }
        }

        private void CargarCuadrosClinicos()
        {
            if (PacienteID <= 0) return;

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT Id, Nombre 
                FROM CuadroClinico
                WHERE PacienteID = @PacienteID
                ORDER BY Nombre;", conn))
            {
                cmd.Parameters.AddWithValue("@PacienteID", PacienteID);
                var dt = new DataTable();
                conn.Open();
                dt.Load(cmd.ExecuteReader());

                cbCuadro.DisplayMember = "Nombre";
                cbCuadro.ValueMember = "Id";
                cbCuadro.DataSource = dt;
                cbCuadro.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void CargarPlan(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"
SELECT Titulo, Descripcion, CuadroClinicoId
FROM PlanTerapeutico WHERE Id=@Id;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        txtTitulo.Text = r["Titulo"]?.ToString();
                        txtDescripcion.Text = r["Descripcion"]?.ToString();
                        cbCuadro.SelectedValue = r["CuadroClinicoId"] == DBNull.Value ? -1 : Convert.ToInt32(r["CuadroClinicoId"]);
                    }
                }
            }
        }

        private void CargarArticulos(int planId)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"
SELECT Nombre, Indicaciones
FROM PlanArticulo
WHERE PlanId=@PlanId
ORDER BY Orden;", conn))
            {
                cmd.Parameters.AddWithValue("@PlanId", planId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    flpArticulos.Controls.Clear();
                    while (r.Read())
                    {
                        AgregarFilaArticulo(out var txtNombre, out var txtInd);
                        txtNombre.Text = r["Nombre"]?.ToString();
                        txtInd.Text = r["Indicaciones"]?.ToString();
                    }
                }
            }

            if (flpArticulos.Controls.Count == 0)
                AgregarFilaArticulo();
        }

        private void AgregarFilaArticulo()
        {
            AgregarFilaArticulo(out _, out _);
        }

        // Usamos Control para compatibilidad con MetroTextBox
        private void AgregarFilaArticulo(out Control txtNombre, out Control txtIndicaciones)
        {
            articuloIndex++;

            // Si ya existe al menos una fila, insertamos un separador ANTES de la nueva fila
            bool hayAlgunaFila = flpArticulos.Controls
                .OfType<Panel>()
                .Any(p => (p.Tag as string) == "filaArticulo");

            if (hayAlgunaFila)
            {
                var separador = new Label
                {
                    Height = 2,
                    BackColor = Color.FromArgb(0, 200, 83), // verde
                    Margin = new Padding(0, 8, 0, 8),
                    Tag = "separator"
                };
                AjustarAnchoControl(separador);
                flpArticulos.Controls.Add(separador);
            }

            var fila = new Panel
            {
                Name = $"filaArticulo_{articuloIndex}",
                Tag = "filaArticulo",
                Height = 130,
                BackColor = Color.FromArgb(17, 17, 17),
                Margin = new Padding(0, 0, 0, 0)
            };

            AjustarAnchoFila(fila);

            var txtNombreMetro = new MetroTextBox
            {
                Name = $"txtArticuloNombre_{articuloIndex}",
                Width = 300,
                Location = new Point(10, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                PromptText = "Nombre del artículo",
                ShowClearButton = false,
                UseSelectable = true
            };
            fila.Controls.Add(txtNombreMetro);

            var lblIndicaciones = new Label
            {
                Text = "Indicaciones",
                ForeColor = Color.White,
                Location = new Point(10, 40),
                AutoSize = true
            };
            fila.Controls.Add(lblIndicaciones);

            var txtIndicacionesMetro = new MetroTextBox
            {
                Name = $"txtArticuloIndicaciones_{articuloIndex}",
                Multiline = true,
                Width = fila.Width - 20,
                Height = 60,
                Location = new Point(10, 60),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                PromptText = "Indicaciones para el artículo...",
                ScrollBars = ScrollBars.Vertical,
                ShowClearButton = false,
                UseSelectable = true
            };
            fila.Controls.Add(txtIndicacionesMetro);

            var btnRemover = new Button
            {
                Text = "Remover",
                BackColor = Color.FromArgb(255, 71, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 28,
                Width = 90,
                Location = new Point(fila.Width - 100, 8)
            };
            btnRemover.FlatAppearance.BorderColor = Color.FromArgb(255, 71, 87);
            btnRemover.FlatAppearance.BorderSize = 2;
            fila.Controls.Add(btnRemover);

            // Asignar a los out como Control (compatible con MetroTextBox)
            txtNombre = txtNombreMetro;
            txtIndicaciones = txtIndicacionesMetro;

            var localTxtIndicaciones = txtIndicacionesMetro;
            var localBtnRemover = btnRemover;

            EventHandler resizeHandler = null;
            resizeHandler = (s, e) =>
            {
                AjustarAnchoFila(fila);

                if (!localBtnRemover.IsDisposed)
                    localBtnRemover.Location = new Point(fila.Width - 100, 8);

                if (!localTxtIndicaciones.IsDisposed)
                    localTxtIndicaciones.Width = fila.Width - 20;
            };
            fila.Resize += resizeHandler;

            btnRemover.Click += (s, e) =>
            {
                // Quitar separador anterior (si existe)
                int idx = flpArticulos.Controls.IndexOf(fila);
                if (idx > 0)
                {
                    var anterior = flpArticulos.Controls[idx - 1];
                    if ((anterior.Tag as string) == "separator")
                    {
                        flpArticulos.Controls.Remove(anterior);
                        anterior.Dispose();
                    }
                }

                fila.Resize -= resizeHandler;
                flpArticulos.Controls.Remove(fila);
                fila.Dispose();
            };

            flpArticulos.Controls.Add(fila);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Indique un título del plan terapéutico.");
                return;
            }
            if (PacienteID <= 0)
            {
                MessageBox.Show("Paciente no válido.");
                return;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                sistema.Infrastructure.Sql.SqlSessionContext.SetAppUser(conn, sistema.Infrastructure.Security.Sesion.UsuarioActual);

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        int planId;

                        if (RecetaID.HasValue)
                        {
                            var up = new SqlCommand(@"
UPDATE PlanTerapeutico
SET Titulo=@Titulo, Descripcion=@Descripcion, CuadroClinicoId=@CuadroClinicoId, FechaUltimaModificacion=GETDATE()
WHERE Id=@Id;", conn, tx);
                            up.Parameters.AddWithValue("@Titulo", txtTitulo.Text.Trim());
                            up.Parameters.AddWithValue("@Descripcion", (object)txtDescripcion.Text.Trim() ?? DBNull.Value);
                            up.Parameters.AddWithValue("@CuadroClinicoId", (object)(cbCuadro.SelectedValue ?? DBNull.Value));
                            up.Parameters.AddWithValue("@Id", RecetaID.Value);
                            up.ExecuteNonQuery();

                            var del = new SqlCommand("DELETE FROM PlanArticulo WHERE PlanId=@PlanId;", conn, tx);
                            del.Parameters.AddWithValue("@PlanId", RecetaID.Value);
                            del.ExecuteNonQuery();

                            planId = RecetaID.Value;
                        }
                        else
                        {
                            var ins = new SqlCommand(@"
INSERT INTO PlanTerapeutico (PacienteID, CuadroClinicoId, Titulo, Descripcion)
VALUES (@PacienteID, @CuadroClinicoId, @Titulo, @Descripcion);
SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tx);
                            ins.Parameters.AddWithValue("@PacienteID", PacienteID);
                            ins.Parameters.AddWithValue("@CuadroClinicoId", (object)(cbCuadro.SelectedValue ?? DBNull.Value));
                            ins.Parameters.AddWithValue("@Titulo", txtTitulo.Text.Trim());
                            ins.Parameters.AddWithValue("@Descripcion", (object)txtDescripcion.Text.Trim() ?? DBNull.Value);

                            planId = (int)ins.ExecuteScalar();
                        }

                        int orden = 1;
                        foreach (Panel fila in flpArticulos.Controls.OfType<Panel>())
                        {
                            var tNombre = fila.Controls.Cast<Control>().FirstOrDefault(t => t.Name.StartsWith("txtArticuloNombre_"));
                            var tInd = fila.Controls.Cast<Control>().FirstOrDefault(t => t.Name.StartsWith("txtArticuloIndicaciones_"));

                            if (tNombre != null && !string.IsNullOrWhiteSpace(tNombre.Text))
                            {
                                var insA = new SqlCommand(@"
INSERT INTO PlanArticulo (PlanId, Nombre, Indicaciones, Orden)
VALUES (@PlanId, @Nombre, @Indicaciones, @Orden);", conn, tx);
                                insA.Parameters.AddWithValue("@PlanId", planId);
                                insA.Parameters.AddWithValue("@Nombre", tNombre.Text.Trim());

                                var indTexto = tInd?.Text;
                                insA.Parameters.AddWithValue("@Indicaciones", string.IsNullOrWhiteSpace(indTexto) ? (object)DBNull.Value : indTexto.Trim());
                                insA.Parameters.AddWithValue("@Orden", orden++);
                                insA.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        MessageBox.Show("Plan terapéutico guardado.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                }
            }
        }
    }
}
