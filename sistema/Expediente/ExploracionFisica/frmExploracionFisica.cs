using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using sistema.Infrastructure.Sql;
using sistema.Infrastructure.Security;

namespace sistema.Expediente.ExploracionFisica
{
    public partial class frmExploracionFisica : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int PacienteID { get; set; }

        public frmExploracionFisica()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        private void frmExploracionFisica_Load(object sender, EventArgs e)
        {
            if (PacienteID > 0)
                CargarUltimaExploracion();
        }

        private void CargarUltimaExploracion()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT TOP(1)
    Temperatura, Peso, Altura,
    TensionSistolica, TensionDiastolica,
    FrecuenciaRespiratoria, FrecuenciaCardiaca,
    SaturacionOxigeno,
    Vision, Olfato, Tacto, Oido, Gusto,
    FechaRegistro
FROM ExploracionFisica
WHERE PacienteID = @PacienteID
ORDER BY FechaRegistro DESC;";
                    cmd.Parameters.AddWithValue("@PacienteID", PacienteID);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return;

                        var culture = CultureInfo.CurrentCulture;

                        int iTemp  = reader.GetOrdinal("Temperatura");
                        int iPeso  = reader.GetOrdinal("Peso");
                        int iAlt   = reader.GetOrdinal("Altura");
                        int iTSis  = reader.GetOrdinal("TensionSistolica");
                        int iTDia  = reader.GetOrdinal("TensionDiastolica");
                        int iFResp = reader.GetOrdinal("FrecuenciaRespiratoria");
                        int iFCard = reader.GetOrdinal("FrecuenciaCardiaca");
                        int iSpO2  = reader.GetOrdinal("SaturacionOxigeno");
                        int iVis   = reader.GetOrdinal("Vision");
                        int iOlf   = reader.GetOrdinal("Olfato");
                        int iTac   = reader.GetOrdinal("Tacto");
                        int iOid   = reader.GetOrdinal("Oido");
                        int iGus   = reader.GetOrdinal("Gusto");

                        // Decimales
                        if (!reader.IsDBNull(iTemp))
                            txtTemperatura.Text = reader.GetDecimal(iTemp).ToString("0.0", culture);
                        if (!reader.IsDBNull(iPeso))
                            txtPeso.Text = reader.GetDecimal(iPeso).ToString("0.##", culture);
                        if (!reader.IsDBNull(iAlt))
                            txtAltura.Text = reader.GetDecimal(iAlt).ToString("0.##", culture);

                        // SmallInt / TinyInt
                        if (!reader.IsDBNull(iTSis))
                            txtTensionSistolica.Text = reader.GetInt16(iTSis).ToString(culture);
                        if (!reader.IsDBNull(iTDia))
                            txtTensionDiastolica.Text = reader.GetInt16(iTDia).ToString(culture);
                        if (!reader.IsDBNull(iFResp))
                            txtFrecuenciaRespiratoria.Text = reader.GetInt16(iFResp).ToString(culture);
                        if (!reader.IsDBNull(iFCard))
                            txtFrecuenciaCardiaca.Text = reader.GetInt16(iFCard).ToString(culture);
                        if (!reader.IsDBNull(iSpO2))
                            txtOxigeno.Text = reader.GetByte(iSpO2).ToString(culture);

                        // Combos: seleccionar si existe el valor; si no, asignar Text
                        SetCombo(cbVision, reader.IsDBNull(iVis) ? null : reader.GetString(iVis));
                        SetCombo(cbOlfato, reader.IsDBNull(iOlf) ? null : reader.GetString(iOlf));
                        SetCombo(cbTacto, reader.IsDBNull(iTac) ? null : reader.GetString(iTac));
                        SetCombo(cbAudicion, reader.IsDBNull(iOid) ? null : reader.GetString(iOid));
                        SetCombo(cbGusto, reader.IsDBNull(iGus) ? null : reader.GetString(iGus));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la última exploración: " + ex.Message);
            }
        }

        private static void SetCombo(ComboBox cb, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            var idx = cb.FindStringExact(value);
            if (idx >= 0) cb.SelectedIndex = idx;
            else cb.Text = value; // por si el valor no está en la lista
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0)
            {
                MessageBox.Show("Paciente inválido.");
                return;
            }

            // Parseo seguro (deja null si está vacío o no es válido)
            decimal? temperatura = TryParseDecimal(txtTemperatura.Text);
            decimal? peso = TryParseDecimal(txtPeso.Text);
            decimal? altura = TryParseDecimal(txtAltura.Text);

            short? tsistolica = TryParseInt16(txtTensionSistolica.Text);
            short? tdiastolica = TryParseInt16(txtTensionDiastolica.Text);
            short? freqResp = TryParseInt16(txtFrecuenciaRespiratoria.Text);
            short? freqCard = TryParseInt16(txtFrecuenciaCardiaca.Text);

            byte? spo2 = TryParseByte(txtOxigeno.Text);

            string vision = NullIfEmpty(cbVision.Text);
            string olfato = NullIfEmpty(cbOlfato.Text);
            string tacto = NullIfEmpty(cbTacto.Text);
            string oido = NullIfEmpty(cbAudicion.Text);
            string gusto = NullIfEmpty(cbGusto.Text);

            // Evita guardar si no hay ningún dato
            if (!temperatura.HasValue && !peso.HasValue && !altura.HasValue &&
                !tsistolica.HasValue && !tdiastolica.HasValue &&
                !freqResp.HasValue && !freqCard.HasValue && !spo2.HasValue &&
                vision == null && olfato == null && tacto == null && oido == null && gusto == null)
            {
                MessageBox.Show("No hay datos para guardar.");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlSessionContext.SetAppUser(conn, Sesion.UsuarioActual);

                    const string sql = @"
INSERT INTO ExploracionFisica
    (PacienteID, Temperatura, Peso, Altura, TensionSistolica, TensionDiastolica,
     FrecuenciaRespiratoria, FrecuenciaCardiaca, SaturacionOxigeno,
     Vision, Olfato, Tacto, Oido, Gusto)
VALUES
    (@PacienteID, @Temperatura, @Peso, @Altura, @TSis, @TDia,
     @FResp, @FCard, @SpO2,
     @Vision, @Olfato, @Tacto, @Oido, @Gusto);";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PacienteID", PacienteID);

                        // Decimales con precisión/escala correctas
                        AddDecimal(cmd, "@Temperatura", 4, 1, temperatura);
                        AddDecimal(cmd, "@Peso", 5, 2, peso);
                        AddDecimal(cmd, "@Altura", 5, 2, altura);

                        // SmallInt / TinyInt
                        AddSmallInt(cmd, "@TSis", tsistolica);
                        AddSmallInt(cmd, "@TDia", tdiastolica);
                        AddSmallInt(cmd, "@FResp", freqResp);
                        AddSmallInt(cmd, "@FCard", freqCard);
                        AddTinyInt(cmd, "@SpO2", spo2);

                        // NVARCHAR(50)
                        AddNVarChar50(cmd, "@Vision", vision);
                        AddNVarChar50(cmd, "@Olfato", olfato);
                        AddNVarChar50(cmd, "@Tacto", tacto);
                        AddNVarChar50(cmd, "@Oido", oido);
                        AddNVarChar50(cmd, "@Gusto", gusto);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Exploración guardada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la exploración: " + ex.Message);
            }
        }

        private static string NullIfEmpty(string s)
            => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private static decimal? TryParseDecimal(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out var v)) return v;
            // Fallback por si el usuario usa separador distinto al regional
            var alt = s.Replace(',', '.');
            if (decimal.TryParse(alt, NumberStyles.Number, CultureInfo.InvariantCulture, out v)) return v;
            return null;
        }

        private static short? TryParseInt16(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            if (short.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out var v)) return v;
            return null;
        }

        private static byte? TryParseByte(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            if (byte.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out var v)) return v;
            return null;
        }

        private static void AddDecimal(SqlCommand cmd, string name, byte precision, byte scale, decimal? value)
        {
            var p = cmd.Parameters.Add(name, SqlDbType.Decimal);
            p.Precision = precision;
            p.Scale = scale;
            p.Value = value.HasValue ? (object)value.Value : DBNull.Value;
        }

        private static void AddSmallInt(SqlCommand cmd, string name, short? value)
        {
            var p = cmd.Parameters.Add(name, SqlDbType.SmallInt);
            p.Value = value.HasValue ? (object)value.Value : DBNull.Value;
        }

        private static void AddTinyInt(SqlCommand cmd, string name, byte? value)
        {
            var p = cmd.Parameters.Add(name, SqlDbType.TinyInt);
            p.Value = value.HasValue ? (object)value.Value : DBNull.Value;
        }

        private static void AddNVarChar50(SqlCommand cmd, string name, string value)
        {
            var p = cmd.Parameters.Add(name, SqlDbType.NVarChar, 50);
            p.Value = value != null ? (object)value : DBNull.Value;
        }
    }
}
