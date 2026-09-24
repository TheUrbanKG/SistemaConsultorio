using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace sistema.Infrastructure
{
    public class BackupService
    {
        private readonly string connectionString;

        public BackupService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        }

        public void RealizarRespaldo(string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino) || !Directory.Exists(rutaDestino))
            {
                throw new ArgumentException("La ruta de destino no es válida o no existe.");
            }

            // Usamos un directorio temporal público para evitar problemas de permisos de escritura de SQL Server.
            string tempFolder = @"C:\TempBackup";
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string fileName = string.Format("tesis_backup_{0}.bak", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            string tempFilePath = Path.Combine(tempFolder, fileName);
            string finalFilePath = Path.Combine(rutaDestino, fileName);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Note: The database name is 'tesis' based on the connection string
                string query = string.Format("BACKUP DATABASE tesis TO DISK = '{0}' WITH FORMAT, INIT;", tempFilePath);

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Increase timeout for backup operation
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Copiar del directorio temporal al destino final
            if (File.Exists(tempFilePath))
            {
                File.Copy(tempFilePath, finalFilePath, true);
                // Eliminar archivo temporal después de copiar
                File.Delete(tempFilePath);
            }
            else
            {
                throw new FileNotFoundException("No se pudo generar el archivo de respaldo temporal.");
            }
        }

        public static string ObtenerRutaConfigurada()
        {
            return ConfigurationManager.AppSettings["BackupPath"] ?? string.Empty;
        }

        public static void GuardarRutaConfigurada(string ruta)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["BackupPath"] == null)
            {
                config.AppSettings.Settings.Add("BackupPath", ruta);
            }
            else
            {
                config.AppSettings.Settings["BackupPath"].Value = ruta;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
