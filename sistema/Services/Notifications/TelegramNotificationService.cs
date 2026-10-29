using sistema.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public class TelegramNotificationService : INotificationService
    {
        // TODO: Reemplaza este texto por el Token real de tu bot (ej. "123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11")
        private readonly string _botToken = "8707599673:AAGDu8hUSO9BjMMwI8qKmK4ZxXbFUTgGVlo"; 

        public async Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(paciente.TelegramChatId))
            {
                throw new Exception("El paciente no tiene un Telegram Chat ID configurado.");
            }

            if (_botToken == "AQUI_VA_EL_TOKEN_DEL_BOTFATHER")
            {
                // Si aún no se ha configurado el Token, seguimos en modo Simulación.
                await Task.Delay(500);
                Console.WriteLine($"[SIMULACIÓN Telegram] Enviando mensaje a {paciente.TelegramChatId}: {mensaje}");
                return true; 
            }

            try
            {
                // Código 100% Funcional para enviar mensaje REAL a Telegram
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://api.telegram.org/bot{_botToken}/sendMessage";
                    var data = new System.Collections.Generic.Dictionary<string, string>
                    {
                        { "chat_id", paciente.TelegramChatId },
                        { "text", mensaje }
                    };

                    var content = new FormUrlEncodedContent(data);
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"[Telegram] Enviado con éxito al ChatId {paciente.TelegramChatId}");
                        return true;
                    }
                    else
                    {
                        string responseError = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Telegram API Error: {responseError}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Telegram] Error enviando a {paciente.TelegramChatId}: {ex.Message}");
                return false;
            }
        }
    }
}
