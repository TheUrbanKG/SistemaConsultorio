using sistema.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public class EmailNotificationService : INotificationService
    {
        // 1. Pon el correo de la clínica aquí (Ej: "clinica.san.jose@gmail.com")
        private readonly string _remitente = "gabrielperezrivas7@gmail.com"; 
        
        // 2. Pon aquí la "Contraseña de aplicación" de Google de 16 letras
        private readonly string _passwordApp = "thwepnjxprhozfue"; 

        public async Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(paciente.Correo))
            {
                throw new Exception("El paciente no tiene correo electrónico configurado.");
            }

            if (_remitente == "TU_CORREO@gmail.com")
            {
                Console.WriteLine("Por favor, configura tu correo y contraseña en EmailNotificationService.cs");
                return true; 
            }

            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_remitente, _passwordApp);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(_remitente, "Sistema de Consultorio Médico");
                        mail.To.Add(new MailAddress(paciente.Correo));
                        mail.Subject = "Recordatorio de Cita Médica";
                        mail.Body = mensaje;
                        mail.IsBodyHtml = false;

                        await smtp.SendMailAsync(mail);
                        Console.WriteLine($"[Email] Enviado con éxito a {paciente.Correo}");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Email] Error enviando a {paciente.Correo}: {ex.Message}");
                return false;
            }
        }
    }
}
