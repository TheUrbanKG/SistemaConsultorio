using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace sistema.Reports
{
    // Clase estática encargada de generar un PDF con el expediente del paciente.
    // Utiliza MigraDoc para construir el documento y PdfDocumentRenderer para exportarlo.
    public static class PdfExporter
    {
        // Exporta todo el expediente de un paciente a un archivo PDF.
        // - pacienteId: identificador del paciente en la base de datos.
        // - connectionString: cadena de conexión a la base de datos.
        // - outputPath: ruta de salida donde se guardará el PDF.
        public static void ExportExpedientePaciente(int pacienteId, string connectionString, string outputPath)
        {
            // Crear documento MigraDoc y una sección principal
            var doc = CrearDocumento();
            var sec = doc.AddSection();

            // Encabezado principal del PDF
            var titulo = sec.AddParagraph("Expediente del Paciente");
            titulo.Format.Font.Size = 16;
            titulo.Format.Font.Bold = true;
            titulo.Format.SpaceAfter = "0.5cm";

            // Abrir conexión y agregar las distintas secciones del expediente
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Cada método agrega una parte del expediente al documento: resumen, antecedentes, alergias, cuadros clínicos, exploración física y planes.
                AgregarResumenPaciente(sec, conn, pacienteId);
                AgregarAntecedentes(sec, conn, pacienteId);
                AgregarAlergias(sec, conn, pacienteId);         // NUEVO
                AgregarCuadrosClinicos(sec, conn, pacienteId);   // NUEVO
                AgregarExploracionFisica(sec, conn, pacienteId);
                AgregarPlanesTerapeuticos(sec, conn, pacienteId);
            }

            // Renderizar y guardar el PDF.
            // PdfDocumentRenderer(true) indica si se embeben las fuentes; aquí se usa compatibilidad con PDFsharp/MigraDoc 6.x
            var renderer = new PdfDocumentRenderer(true)
            {
                Document = doc
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(outputPath);
        }

        // Exporta un reporte consolidado de citas a un archivo PDF.
        public static void ExportReporteCitas(DataTable citas, string tituloReporte, string outputPath)
        {
            var doc = CrearDocumento();
            doc.Info.Title = tituloReporte;
            var sec = doc.AddSection();
            
            // Configurar página en Horizontal para que las columnas quepan bien
            sec.PageSetup.Orientation = Orientation.Landscape;
            sec.PageSetup.TopMargin = "1.5cm";
            sec.PageSetup.BottomMargin = "2cm";
            sec.PageSetup.LeftMargin = "1.5cm";
            sec.PageSetup.RightMargin = "1.5cm";

            // Título Principal
            var titulo = sec.AddParagraph(tituloReporte);
            titulo.Format.Font.Size = 18;
            titulo.Format.Font.Bold = true;
            titulo.Format.Font.Color = Colors.DarkSlateBlue;
            titulo.Format.Alignment = ParagraphAlignment.Center;
            titulo.Format.SpaceAfter = "1cm";

            // Footer con fecha y número de página
            var footer = sec.Footers.Primary.AddParagraph();
            footer.AddText("Generado el: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "   |   Página ");
            footer.AddPageField();
            footer.AddText(" de ");
            footer.AddNumPagesField();
            footer.Format.Alignment = ParagraphAlignment.Center;
            footer.Format.Font.Size = 9;
            footer.Format.Font.Color = Colors.Gray;

            if (citas == null || citas.Rows.Count == 0)
            {
                var p = sec.AddParagraph("No hay citas registradas para los filtros seleccionados.");
                p.Format.Alignment = ParagraphAlignment.Center;
                p.Format.Font.Italic = true;
            }
            else
            {
                var tabla = sec.AddTable();
                tabla.Borders.Width = 0.5;
                tabla.Borders.Color = Colors.LightGray;
                
                // Definir las columnas ajustadas al formato horizontal (~26 cm de espacio)
                tabla.AddColumn("3.0cm");  // Fecha
                tabla.AddColumn("2.5cm");  // Hora
                tabla.AddColumn("6.5cm");  // Paciente
                tabla.AddColumn("3.5cm");  // Telefono
                tabla.AddColumn("7.5cm");  // Motivo
                tabla.AddColumn("3.0cm");  // Estado

                var header = tabla.AddRow();
                header.HeadingFormat = true; // Se repite si hay múltiples páginas
                header.Format.Font.Bold = true;
                header.Format.Font.Color = Colors.White;
                header.Shading.Color = Colors.SteelBlue;

                header.Cells[0].AddParagraph("Fecha");
                header.Cells[1].AddParagraph("Hora");
                header.Cells[2].AddParagraph("Paciente");
                header.Cells[3].AddParagraph("Teléfono");
                header.Cells[4].AddParagraph("Motivo");
                header.Cells[5].AddParagraph("Estado");

                // Dar formato centrado y con espaciado al header
                for (int i = 0; i < 6; i++)
                {
                    header.Cells[i].VerticalAlignment = VerticalAlignment.Center;
                    header.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                    header.Cells[i].Format.SpaceBefore = "0.2cm";
                    header.Cells[i].Format.SpaceAfter = "0.2cm";
                }

                bool zebra = false;
                foreach (DataRow r in citas.Rows)
                {
                    var row = tabla.AddRow();
                    row.VerticalAlignment = VerticalAlignment.Center;
                    if (zebra)
                        row.Shading.Color = Colors.AliceBlue;
                    zebra = !zebra;

                    var fecha = r["FechaCita"] != DBNull.Value ? ((DateTime)r["FechaCita"]).ToString("dd/MM/yyyy") : "";
                    var hora = r["HoraCita"] != DBNull.Value ? ((TimeSpan)r["HoraCita"]).ToString(@"hh\:mm") + " " + r["Periodo"] : "";
                    var paciente = $"{r["Nombre"]} {r["Apellido"]}".Trim();
                    
                    row.Cells[0].AddParagraph(fecha);
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                    
                    row.Cells[1].AddParagraph(hora);
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                    
                    row.Cells[2].AddParagraph(paciente);
                    row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                    
                    row.Cells[3].AddParagraph(r["Telefono"]?.ToString() ?? "");
                    row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
                    
                    row.Cells[4].AddParagraph(r["Motivo"]?.ToString() ?? "");
                    row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                    
                    row.Cells[5].AddParagraph(r["Status"]?.ToString() ?? "");
                    row.Cells[5].Format.Alignment = ParagraphAlignment.Center;

                    for (int i = 0; i < 6; i++)
                    {
                        row.Cells[i].Format.SpaceBefore = "0.15cm";
                        row.Cells[i].Format.SpaceAfter = "0.15cm";
                    }
                }
            }

            var renderer = new PdfDocumentRenderer(true)
            {
                Document = doc
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(outputPath);
        }

        // Crea y configura el documento básico (estilos, metadatos).
        private static Document CrearDocumento()
        {
            var doc = new Document();
            doc.Info.Title = "Expediente del Paciente";
            doc.Info.Subject = "Resumen consolidado del expediente clínico";
            doc.Info.Author = "Sistema Consultorio";

            // Estilo por defecto
            var style = doc.Styles["Normal"];
            style.Font.Name = "Segoe UI";
            style.Font.Size = 9;

            // Estilo para encabezados (Heading1)
            var h1 = doc.Styles.AddStyle("Heading1", "Normal");
            h1.Font.Size = 13;
            h1.Font.Bold = true;
            h1.ParagraphFormat.SpaceBefore = "0.5cm";
            h1.ParagraphFormat.SpaceAfter = "0.2cm";

            return doc;
        }

        // Agrega la sección con los datos básicos del paciente (nombre, cédula, género, fecha de nacimiento, contacto, etc.).
        private static void AgregarResumenPaciente(Section sec, SqlConnection conn, int pacienteId)
        {
            using (var cmd = new SqlCommand(@"
            SELECT Cedula, Nombre, Apellido, Genero, FechaNacimiento, Telefono, Direccion, FechaRegistro, GrupoSanguineo
            FROM Paciente WHERE PacienteID = @Id;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        // Si no existe el paciente, agregar mensaje y retornar
                        sec.AddParagraph("Paciente no encontrado.", "Heading1");
                        return;
                    }

                    var r = dt.Rows[0];
                    sec.AddParagraph("Datos del Paciente", "Heading1");

                    // Construye una tabla simple con dos columnas para mostrar los datos clave.
                    var tabla = sec.AddTable();
                    tabla.Borders.Width = 0.5;

                    tabla.AddColumn("4cm");
                    tabla.AddColumn("12cm");

                    void fila(string k, string v)
                    {
                        var row = tabla.AddRow();
                        row.Cells[0].AddParagraph(k);
                        row.Cells[0].Format.Font.Bold = true;
                        row.Cells[1].AddParagraph(v ?? "");
                    }

                    var nombreCompleto = $"{r["Nombre"]} {r["Apellido"]}".Trim();
                    var fechaNac = r["FechaNacimiento"] != DBNull.Value ? ((DateTime)r["FechaNacimiento"]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : "";
                    var fechaReg = r["FechaRegistro"] != DBNull.Value ? ((DateTime)r["FechaRegistro"]).ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture) : "";
                    var grupo = r["GrupoSanguineo"]?.ToString();

                    // Agrega filas con etiquetas y valores
                    fila("Nombre", nombreCompleto);
                    fila("Cédula", r["Cedula"]?.ToString());
                    fila("Género", NormalizarGenero(r["Genero"]?.ToString()));
                    fila("Grupo sanguíneo", string.IsNullOrWhiteSpace(grupo) ? "N/D" : grupo);
                    fila("Fecha de Nacimiento", fechaNac);
                    fila("Teléfono", r["Telefono"]?.ToString());
                    fila("Dirección", r["Direccion"]?.ToString());
                    fila("Fecha Registro", fechaReg);
                }
            }
        }

        // Agrega secciones de antecedentes patológicos y personales.
        private static void AgregarAntecedentes(Section sec, SqlConnection conn, int pacienteId)
        {
            // Antecedentes patológicos: lee la primera fila y añade entradas para cada condición marcada.
            using (var cmd = new SqlCommand(@"
                SELECT TOP (1)
                Hipertension, Tuberculosis, Diabetes, Obesidad, Tiroides, Dislipidemia,
                Sarampion, Rubeola, Tosferina, Varicela, Artritis, Osteoporosis,
                OtroPadecimiento, Padecimiento
                FROM AntecedentePatologico WHERE PacienteID = @Id;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    sec.AddParagraph("Antecedentes Patológicos", "Heading1");

                    if (dt.Rows.Count == 0)
                    {
                        sec.AddParagraph("Sin antecedentes patológicos registrados.");
                    }
                    else
                    {
                        var r = dt.Rows[0];

                        // Función local para añadir una línea si el campo booleano es verdadero
                        void addIfTrue(string nombreCampo, string etiqueta)
                        {
                            if (AsBool(r[nombreCampo]))
                                sec.AddParagraph("• " + etiqueta);
                        }

                        addIfTrue("Hipertension", "Hipertensión");
                        addIfTrue("Tuberculosis", "Tuberculosis");
                        addIfTrue("Diabetes", "Diabetes");
                        addIfTrue("Obesidad", "Obesidad");
                        addIfTrue("Tiroides", "Tiroides");
                        addIfTrue("Dislipidemia", "Dislipidemia");
                        addIfTrue("Sarampion", "Sarampión");
                        addIfTrue("Rubeola", "Rubéola");
                        addIfTrue("Tosferina", "Tosferina");
                        addIfTrue("Varicela", "Varicela");
                        addIfTrue("Artritis", "Artritis");
                        addIfTrue("Osteoporosis", "Osteoporosis");

                        var otro = AsBool(r["OtroPadecimiento"]);
                        var padec = r["Padecimiento"]?.ToString();
                        if (otro && !string.IsNullOrWhiteSpace(padec))
                            sec.AddParagraph("• Otro: " + padec);
                        else if (otro)
                            sec.AddParagraph("• Otro padecimiento.");
                    }
                }
            }

            // Antecedentes personales: manejar como campos textuales (no sólo booleanos)
            using (var cmd = new SqlCommand(@"
                SELECT TOP (1) Tabaco, Alcohol, Mascotas, Servicios, Vivienda, FechaActualizacion
                FROM AntecedentePersonal WHERE PacienteID = @Id;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    sec.AddParagraph("Antecedentes Personales", "Heading1");

                    if (dt.Rows.Count == 0)
                    {
                        sec.AddParagraph("Sin antecedentes personales registrados.");
                    }
                    else
                    {
                        var r = dt.Rows[0];
                        var fecha = r["FechaActualizacion"] != DBNull.Value
                            ? ((DateTime)r["FechaActualizacion"]).ToString("dd/MM/yyyy HH:mm")
                            : null;

                        if (fecha != null)
                            sec.AddParagraph("Última actualización: " + fecha);

                        // Leer como strings y mostrarlos si contienen valor
                        string tabaco = r["Tabaco"] == DBNull.Value ? null : r["Tabaco"].ToString().Trim();
                        string alcohol = r["Alcohol"] == DBNull.Value ? null : r["Alcohol"].ToString().Trim();
                        string mascotas = r["Mascotas"] == DBNull.Value ? null : r["Mascotas"].ToString().Trim();
                        string servicios = r["Servicios"] == DBNull.Value ? null : r["Servicios"].ToString().Trim();
                        string vivienda = r["Vivienda"] == DBNull.Value ? null : r["Vivienda"].ToString().Trim();

                        if (!string.IsNullOrWhiteSpace(tabaco))
                            sec.AddParagraph("• Tabaco: " + tabaco);

                        if (!string.IsNullOrWhiteSpace(alcohol))
                            sec.AddParagraph("• Alcohol: " + alcohol);

                        if (!string.IsNullOrWhiteSpace(mascotas))
                            sec.AddParagraph("• Mascotas: " + mascotas);

                        if (!string.IsNullOrWhiteSpace(servicios))
                            sec.AddParagraph("• Servicios: " + servicios);

                        if (!string.IsNullOrWhiteSpace(vivienda))
                            sec.AddParagraph("• Vivienda: " + vivienda);
                    }
                }
            }
        }

        // Agrega una tabla con las alergias registradas del paciente.
        private static void AgregarAlergias(Section sec, SqlConnection conn, int pacienteId)
        {
            using (var cmd = new SqlCommand(@"
            SELECT Nombre, Tipo, Severidad, EstadoClinico, FechaUltimaModificacion
            FROM Alergia
            WHERE PacienteID = @Id
            ORDER BY FechaUltimaModificacion DESC;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    sec.AddParagraph("Alergias", "Heading1");

                    if (dt.Rows.Count == 0)
                    {
                        sec.AddParagraph("Sin alergias registradas.");
                        return;
                    }

                    // Construcción de tabla con columnas fijas para mostrar cada alergia
                    var tabla = sec.AddTable();
                    tabla.Borders.Width = 0.5;
                    tabla.AddColumn("5.5cm"); // Nombre
                    tabla.AddColumn("3.0cm"); // Tipo
                    tabla.AddColumn("3.0cm"); // Severidad
                    tabla.AddColumn("3.5cm"); // Estado
                    tabla.AddColumn("2.0cm"); // Fecha

                    var header = tabla.AddRow();
                    AddHeader(header, "Nombre", "Tipo", "Severidad", "Estado clínico", "Fecha");

                    // Recorre filas y añade contenido
                    foreach (DataRow r in dt.Rows)
                    {
                        var row = tabla.AddRow();
                        row.Cells[0].AddParagraph(r["Nombre"]?.ToString());
                        row.Cells[1].AddParagraph(r["Tipo"]?.ToString());
                        row.Cells[2].AddParagraph(r["Severidad"]?.ToString());
                        row.Cells[3].AddParagraph(r["EstadoClinico"]?.ToString());
                        row.Cells[4].AddParagraph(r["FechaUltimaModificacion"] == DBNull.Value
                            ? ""
                            : ((DateTime)r["FechaUltimaModificacion"]).ToString("dd/MM/yyyy"));
                    }
                }
            }
        }

        // Agrega cuadros clínicos. Intenta leer desde la tabla CuadroClinico y si no hay datos, obtiene información desde PlanTerapeutico (fallback).
        private static void AgregarCuadrosClinicos(Section sec, SqlConnection conn, int pacienteId)
        {
            sec.AddParagraph("Cuadros clínicos", "Heading1");

            // 1) Intentar desde tabla CuadroClinico vinculada al paciente
            using (var cmd = new SqlCommand(@"SELECT * FROM CuadroClinico WHERE PacienteID = @Id;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        PintarTablaCuadros(sec, dt);
                        return;
                    }
                }
            }

            // 2) Fallback: cuadros usados en planes terapéuticos del paciente
            using (var cmd2 = new SqlCommand(@"
            SELECT c.Id, c.Nombre, c.Impresiones AS Descripcion, MAX(p.FechaCreacion) AS UltimaFecha
            FROM PlanTerapeutico p
            INNER JOIN CuadroClinico c ON c.Id = p.CuadroClinicoId
            WHERE p.PacienteID = @Id
            GROUP BY c.Id, c.Nombre, c.Impresiones
            ORDER BY UltimaFecha DESC;", conn))
            {
                cmd2.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd2))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        sec.AddParagraph("Sin cuadros clínicos registrados.");
                        return;
                    }
                    PintarTablaCuadros(sec, dt);
                }
            }
        }

        // Dibuja una tabla genérica para cuadros clínicos. Maneja columnas opcionales (Impresiones/Descripcion/Estado/Fechas).
        private static void PintarTablaCuadros(Section sec, DataTable dt)
        {
            var tabla = sec.AddTable();
            tabla.Borders.Width = 0.5;
            tabla.AddColumn("6.0cm"); // Nombre
            tabla.AddColumn("6.5cm"); // Descripción / Impresiones
            tabla.AddColumn("3.0cm"); // Estado / Fecha(s)

            // Encabezados dinámicos
            string colNombre = "Nombre";

            // Prioriza Impresiones como descripción; si no, usa Descripcion/Descripción
            string colDesc =
                dt.Columns.Contains("Impresiones") ? "Impresiones" :
                dt.Columns.Contains("Descripcion") ? "Descripcion" :
                dt.Columns.Contains("Descripción") ? "Descripción" : null;

            string colEstado = dt.Columns.Contains("Estado") ? "Estado" : null;

            bool hasInicioFin = dt.Columns.Contains("FechaInicio") && dt.Columns.Contains("FechaFin");
            string colFecha =
                dt.Columns.Contains("UltimaFecha") ? "UltimaFecha" :
                dt.Columns.Contains("FechaUltimaModificacion") ? "FechaUltimaModificacion" :
                dt.Columns.Contains("FechaDiagnostico") ? "FechaDiagnostico" : null;

            var header3 = colEstado != null ? "Estado" : ((hasInicioFin || colFecha != null) ? "Fecha" : "");

            var header = tabla.AddRow();
            AddHeader(header, "Nombre", colDesc != null ? "Descripción" : "", header3);

            // Para cada fila, escribe nombre, descripción (si existe) y una tercera columna con estado o fechas según disponibilidad.
            foreach (DataRow r in dt.Rows)
            {
                var row = tabla.AddRow();
                row.Cells[0].AddParagraph(r[colNombre]?.ToString());

                // Descripción si existe (Impresiones/Descripcion/Descripción)
                row.Cells[1].AddParagraph(colDesc != null ? (r[colDesc]?.ToString() ?? "") : "");

                // Tercera columna: Estado o Fechas
                string valorTercera = "";
                if (colEstado != null)
                {
                    valorTercera = r[colEstado]?.ToString();
                }
                else if (hasInicioFin)
                {
                    // Si hay fechas de inicio/fin, las formatea
                    var inicio = r["FechaInicio"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["FechaInicio"]);
                    var fin = r["FechaFin"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["FechaFin"]);
                    if (inicio.HasValue || fin.HasValue)
                    {
                        if (inicio.HasValue && fin.HasValue)
                            valorTercera = $"Inicio: {inicio.Value:dd/MM/yyyy}  Fin: {fin.Value:dd/MM/yyyy}";
                        else if (inicio.HasValue)
                            valorTercera = $"Inicio: {inicio.Value:dd/MM/yyyy}";
                        else
                            valorTercera = $"Fin: {fin.Value:dd/MM/yyyy}";
                    }
                }
                else if (colFecha != null && r[colFecha] != DBNull.Value)
                {
                    var fecha = Convert.ToDateTime(r[colFecha]);
                    valorTercera = fecha.ToString("dd/MM/yyyy HH:mm");
                }

                row.Cells[2].AddParagraph(valorTercera);
            }
        }

        // Agrega la última exploración física registrada como una tabla de pares clave-valor.
        private static void AgregarExploracionFisica(Section sec, SqlConnection conn, int pacienteId)
        {
            using (var cmd = new SqlCommand(@"
            SELECT TOP (1)
            Temperatura, Peso, Altura, TensionSistolica, TensionDiastolica,
            FrecuenciaRespiratoria, FrecuenciaCardiaca, SaturacionOxigeno,
            Vision, Olfato, Tacto, Oido, Gusto, FechaRegistro
            FROM ExploracionFisica
            WHERE PacienteID = @Id
            ORDER BY FechaRegistro DESC;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    sec.AddParagraph("Última Exploración Física", "Heading1");

                    if (dt.Rows.Count == 0)
                    {
                        sec.AddParagraph("Sin exploración física registrada.");
                    }
                    else
                    {
                        var r = dt.Rows[0];
                        var tabla = sec.AddTable();
                        tabla.Borders.Width = 0.5;
                        tabla.AddColumn("6cm");
                        tabla.AddColumn("10cm");

                        void fila(string k, string v)
                        {
                            var row = tabla.AddRow();
                            row.Cells[0].AddParagraph(k);
                            row.Cells[0].Format.Font.Bold = true;
                            row.Cells[1].AddParagraph(v ?? "");
                        }

                        // Helper que formatea números si existen
                        string fmt(object o, string format = null) =>
                            o == DBNull.Value ? null :
                            (o is IFormattable f ? f.ToString(format ?? "0.##", CultureInfo.InvariantCulture) : o.ToString());

                        // Añade filas para las distintas mediciones y observaciones
                        fila("Fecha", r["FechaRegistro"] == DBNull.Value ? "" : ((DateTime)r["FechaRegistro"]).ToString("dd/MM/yyyy HH:mm"));
                        fila("Temperatura (°C)", fmt(r["Temperatura"], "0.0"));
                        fila("Peso (kg)", fmt(r["Peso"]));
                        fila("Altura (m)", fmt(r["Altura"]));
                        fila("Tensión (mmHg)", Join2(fmt(r["TensionSistolica"], "0"), fmt(r["TensionDiastolica"], "0"), "/"));
                        fila("Frecuencia Resp. (rpm)", fmt(r["FrecuenciaRespiratoria"], "0"));
                        fila("Frecuencia Card. (lpm)", fmt(r["FrecuenciaCardiaca"], "0"));
                        fila("SpO2 (%)", fmt(r["SaturacionOxigeno"], "0"));
                        fila("Visión", r["Vision"]?.ToString());
                        fila("Olfato", r["Olfato"]?.ToString());
                        fila("Tacto", r["Tacto"]?.ToString());
                        fila("Oído", r["Oido"]?.ToString());
                        fila("Gusto", r["Gusto"]?.ToString());
                    }
                }
            }
        }

        // Agrega los planes terapéuticos del paciente: título, fecha, descripción y artículos asociados.
        private static void AgregarPlanesTerapeuticos(Section sec, SqlConnection conn, int pacienteId)
        {
            using (var cmd = new SqlCommand(@"
            SELECT Id, Titulo, Descripcion, FechaCreacion
            FROM PlanTerapeutico
            WHERE PacienteID = @Id
            ORDER BY FechaCreacion DESC;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", pacienteId);
                using (var da = new SqlDataAdapter(cmd))
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    sec.AddParagraph("Planes Terapéuticos", "Heading1");

                    if (dt.Rows.Count == 0)
                    {
                        sec.AddParagraph("Sin planes registrados.");
                        return;
                    }

                    foreach (DataRow p in dt.Rows)
                    {
                        // Título en mayúsculas y en negrita
                        var t = sec.AddParagraph((p["Titulo"]?.ToString() ?? "").ToUpperInvariant());
                        t.Format.Font.Bold = true;

                        var f = p["FechaCreacion"] != DBNull.Value ? ((DateTime)p["FechaCreacion"]).ToString("dd/MM/yyyy HH:mm") : "";
                        if (!string.IsNullOrWhiteSpace(f))
                            sec.AddParagraph("Fecha: " + f);

                        var desc = p["Descripcion"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(desc))
                            sec.AddParagraph(desc);

                        // Obtener artículos asociados al plan terapéutico y listarlos con indicaciones
                        using (var cmdArt = new SqlCommand(@"
                        SELECT Nombre, Indicaciones, Orden
                        FROM PlanArticulo
                        WHERE PlanId = @PlanId
                        ORDER BY Orden;", conn))
                        {
                            cmdArt.Parameters.AddWithValue("@PlanId", (int)p["Id"]);
                            using (var daArt = new SqlDataAdapter(cmdArt))
                            using (var dtArt = new DataTable())
                            {
                                daArt.Fill(dtArt);
                                foreach (DataRow a in dtArt.Rows)
                                {
                                    var nombre = a["Nombre"]?.ToString();
                                    var ind = a["Indicaciones"]?.ToString();
                                    if (!string.IsNullOrWhiteSpace(nombre))
                                    {
                                        sec.AddParagraph("• " + nombre);
                                        if (!string.IsNullOrWhiteSpace(ind))
                                        {
                                            var par = sec.AddParagraph("   Indicaciones: " + ind);
                                            par.Format.Font.Italic = true;
                                        }
                                    }
                                }
                            }
                        }

                        // Espacio entre planes
                        sec.AddParagraph().Format.SpaceAfter = "0.3cm";
                    }
                }
            }
        }

        // Normaliza el texto del género a una representación legible.
        private static string NormalizarGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero)) return "N/D";
            switch (genero.Trim().ToUpperInvariant())
            {
                case "M":
                case "MASCULINO": return "Masculino";
                case "F":
                case "FEMENINO": return "Femenino";
                default: return genero;
            }
        }

        // Une dos cadenas con un separador, manejando nulos o vacíos.
        private static string Join2(string a, string b, string sep)
        {
            if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b)) return null;
            if (string.IsNullOrWhiteSpace(a)) return b;
            if (string.IsNullOrWhiteSpace(b)) return a;
            return a + sep + b;
        }

        // Añade encabezados a una fila de tabla (negrita y fondo gris claro).
        private static void AddHeader(Row header, params string[] textos)
        {
            for (int i = 0; i < textos.Length; i++)
            {
                header.Cells[i].AddParagraph(textos[i]);
                header.Cells[i].Format.Font.Bold = true;
                header.Cells[i].Shading.Color = Colors.LightGray;
            }
        }

        // Convierte distintos tipos de valores a booleano de forma robusta.
        // Acepta valores bit/número, cadenas "1"/"0", "true"/"false", "si"/"no", etc.
        private static bool AsBool(object value)
        {
            if (value == null || value == DBNull.Value) return false;

            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Boolean:
                    return (bool)value;
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    try { return Convert.ToInt64(value) != 0; } catch { return false; }
                case TypeCode.String:
                    var s = (value as string)?.Trim();
                    if (string.IsNullOrEmpty(s)) return false;
                    // normalizaciones comunes
                    if (s.Equals("1")) return true;
                    if (s.Equals("0")) return false;
                    if (bool.TryParse(s, out var b)) return b;
                    if (int.TryParse(s, out var n)) return n != 0;
                    if (s.Equals("SI", StringComparison.OrdinalIgnoreCase) || s.Equals("SÍ", StringComparison.OrdinalIgnoreCase)) return true;
                    if (s.Equals("NO", StringComparison.OrdinalIgnoreCase)) return false;
                    return false;
                default:
                    try { return Convert.ToBoolean(value); } catch { return false; }
            }
        }
    }
}