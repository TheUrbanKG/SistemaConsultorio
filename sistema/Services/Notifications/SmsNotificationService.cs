using sistema.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public class SmsNotificationService : INotificationService
    {
        public async Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(paciente.Telefono))
            {
                throw new Exception("El paciente no tiene un número de teléfono configurado.");
            }

            try
            {
                // Limpiar el teléfono (se requiere código de país, ej: 584141234567)
                string telefonoLimpio = paciente.Telefono.Replace("+", "").Replace(" ", "").Replace("-", "");

                using (HttpClient client = new HttpClient())
                {
                    // Usamos Textbelt: API gratuita para 1 SMS al día
                    var data = new System.Collections.Generic.Dictionary<string, string>
                    {
                        { "phone", telefonoLimpio },
                        { "message", mensaje },
                        { "key", "textbelt" } 
                    };

                    var content = new FormUrlEncodedContent(data);
                    HttpResponseMessage response = await client.PostAsync("https://textbelt.com/text", content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        // Textbelt devuelve un JSON: {"success":true,"textId":"...","quotaRemaining":0}
                        if (result.Contains("\"success\":true") || result.Contains("\"success\": true"))
                        {
                            Console.WriteLine($"[SMS] Enviado con éxito a {telefonoLimpio}");
                            return true;
                        }
                        else
                        {
                            throw new Exception($"El servicio de SMS denegó el envío (quizás agotaste tu 1 SMS diario): {result}");
                        }
                    }
                    else
                    {
                        string responseError = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error HTTP al conectar con SMS: {responseError}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SMS] Error enviando a {paciente.Telefono}: {ex.Message}");
                return false; // Al retornar false, el Worker tira el popup de Error pero no cae
            }
        }
    }
}
