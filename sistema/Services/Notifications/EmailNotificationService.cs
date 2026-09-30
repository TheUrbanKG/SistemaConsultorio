using sistema.Models;
using System;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public class EmailNotificationService : INotificationService
    {
        public async Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(paciente.Correo))
            {
                throw new Exception("El paciente no tiene un correo electrónico configurado.");
            }

            try
            {
                // Aquí iría la integración con MailKit o System.Net.Mail
                // System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                // ...
                
                // Simulación para fines de completitud estructural
                await Task.Delay(500); 
                Console.WriteLine($"[Email] Enviando correo a {paciente.Correo}: {mensaje}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Email] Error enviando a {paciente.Correo}: {ex.Message}");
                return false;
            }
        }
    }
}
