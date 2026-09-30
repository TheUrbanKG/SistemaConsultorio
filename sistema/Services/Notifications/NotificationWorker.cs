using sistema.Data;
using sistema.Models;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema.Services.Notifications
{
    public class NotificationWorker
    {
        private readonly Timer _timer;
        private readonly CitaRepository _citaRepo;
        private readonly HistorialNotificacionesRepository _historialRepo;

        public NotificationWorker()
        {
            _citaRepo = new CitaRepository();
            _historialRepo = new HistorialNotificacionesRepository();
            
            _timer = new Timer();
            // Ejecutar cada 15 minutos (900,000 ms)
            _timer.Interval = 900000; 
            _timer.Tick += async (s, e) => await ProcesarNotificaciones();
        }

        public void Iniciar()
        {
            _timer.Start();
            // Ejecutamos la primera vez de forma asíncrona pero sin bloquear el hilo principal
            Task.Run(async () => await ProcesarNotificaciones());
        }

        public void Detener()
        {
            _timer.Stop();
        }

        private async Task ProcesarNotificaciones()
        {
            try
            {
                DateTime hoy = DateTime.Today;
                DateTime manana = hoy.AddDays(1);
                
                // Obtenemos citas de mañana (aviso 24h) con preferencias configuradas
                DataTable citasManana = _citaRepo.ObtenerCitasParaNotificar(manana);

                foreach (DataRow row in citasManana.Rows)
                {
                    int citaID = Convert.ToInt32(row["CitaID"]);
                    string canal = row["CanalNotificacionPreferido"].ToString();
                    
                    if (_historialRepo.YaSeEnvioNotificacion(citaID, canal))
                    {
                        continue; // Ya notificado
                    }

                    // Construimos modelo del paciente desde el DataRow
                    Paciente paciente = new Paciente
                    {
                        PacienteID = Convert.ToInt32(row["PacienteID"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Telefono = row["Telefono"].ToString(),
                        Correo = row["Correo"].ToString(),
                        CanalNotificacionPreferido = canal,
                        TelegramChatId = row["TelegramChatId"] == DBNull.Value ? null : row["TelegramChatId"].ToString()
                    };

                    DateTime fechaCita = Convert.ToDateTime(row["FechaCita"]);
                    TimeSpan horaCita = (TimeSpan)row["HoraCita"];
                    string mensaje = $"Hola {paciente.Nombre}, le recordamos su cita para el día {fechaCita:dd/MM/yyyy} a las {horaCita:hh\\:mm}. ¡Le esperamos!";

                    try
                    {
                        var service = NotificationStrategyFactory.GetService(canal);
                        bool exito = await service.EnviarNotificacionAsync(paciente, mensaje);

                        string estado = exito ? "Enviado" : "Error";
                        string errorMsg = exito ? null : "El servicio retornó false al enviar el mensaje.";
                        _historialRepo.RegistrarNotificacion(citaID, canal, estado, errorMsg);
                    }
                    catch (Exception ex)
                    {
                        _historialRepo.RegistrarNotificacion(citaID, canal, "Error", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error crítico en NotificationWorker: " + ex.Message);
            }
        }
    }
}
