using sistema.Models;
using System;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public class TwilioNotificationService : INotificationService
    {
        private readonly bool _useWhatsApp;

        public TwilioNotificationService(bool useWhatsApp)
        {
            _useWhatsApp = useWhatsApp;
        }

        public async Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(paciente.Telefono))
            {
                throw new Exception("El paciente no tiene un número de teléfono configurado.");
            }

            try
            {
                // Integración con Twilio SDK
                // TwilioClient.Init(accountSid, authToken);
                // var prefix = _useWhatsApp ? "whatsapp:" : "";
                // var to = new PhoneNumber(prefix + paciente.Telefono);
                // var from = new PhoneNumber(prefix + "TU_NUMERO_TWILIO");
                // await MessageResource.CreateAsync(to: to, from: from, body: mensaje);

                await Task.Delay(500); // Simulando red
                string canalLog = _useWhatsApp ? "WhatsApp" : "SMS";
                Console.WriteLine($"[{canalLog}] Enviando a {paciente.Telefono}: {mensaje}");
                return true;
            }
            catch (Exception ex)
            {
                string canalLog = _useWhatsApp ? "WhatsApp" : "SMS";
                Console.WriteLine($"[{canalLog}] Error enviando a {paciente.Telefono}: {ex.Message}");
                return false;
            }
        }
    }
}
