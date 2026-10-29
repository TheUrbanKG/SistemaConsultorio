using sistema.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public class TwilioNotificationService : INotificationService
    {
        // Pega aquí la API Key que te dé el bot
        private readonly string _apikey = "API_KEY_AQUI"; 

        public async Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(paciente.Telefono))
            {
                throw new Exception("El paciente no tiene un número de teléfono configurado.");
            }

            if (_apikey == "API_KEY_AQUI")
            {
                await Task.Delay(500);
                Console.WriteLine($"[SIMULACIÓN WhatsApp] Enviando mensaje al {paciente.Telefono}");
                return true;
            }

            try
            {
                // CallMeBot requiere el número con código de país, pero sin el signo '+'. Ej: 584141234567
                string telefonoLimpio = paciente.Telefono.Replace("+", "").Replace(" ", "").Replace("-", "");

                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://api.callmebot.com/whatsapp.php?phone={telefonoLimpio}&text={Uri.EscapeDataString(mensaje)}&apikey={_apikey}";
                    
                    HttpResponseMessage response = await client.GetAsync(url);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"[WhatsApp] Enviado con éxito a {telefonoLimpio}");
                        return true;
                    }
                    else
                    {
                        string responseError = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error WhatsApp: {responseError}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WhatsApp] Error enviando a {paciente.Telefono}: {ex.Message}");
                return false;
            }
        }
    }
}
