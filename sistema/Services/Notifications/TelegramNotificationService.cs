using sistema.Models;
using System;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public class TelegramNotificationService : INotificationService
    {
        public async Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(paciente.TelegramChatId))
            {
                throw new Exception("El paciente no tiene un Telegram Chat ID configurado.");
            }

            try
            {
                // Integración con Telegram Bot API
                // var botClient = new Telegram.Bot.TelegramBotClient("TU_TOKEN_AQUI");
                // await botClient.SendTextMessageAsync(chatId: paciente.TelegramChatId, text: mensaje);
                
                await Task.Delay(500); // Simulando red
                Console.WriteLine($"[Telegram] Enviando mensaje al ChatId {paciente.TelegramChatId}: {mensaje}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Telegram] Error enviando a {paciente.TelegramChatId}: {ex.Message}");
                return false;
            }
        }
    }
}
