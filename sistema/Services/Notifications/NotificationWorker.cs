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
            // Ejecutar cada 10 segundos para hacer pruebas rápidas (10,000 ms)
            _timer.Interval = 10000; 
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
                    DateTime citaCombinada = fechaCita.Add(horaCita);
                    string mensaje = $"Hola {paciente.Nombre}, le recordamos su cita para el día {fechaCita:dd/MM/yyyy} a las {citaCombinada:h:mm tt}. ¡Le esperamos!";

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
