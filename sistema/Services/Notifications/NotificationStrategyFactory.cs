using sistema.Models;
using System;

namespace sistema.Services.Notifications
{
    public class NotificationStrategyFactory
    {
        public static INotificationService GetService(string canalPreferido)
        {
            switch (canalPreferido?.ToUpper())
            {
                case "EMAIL":
                    return new EmailNotificationService();
                case "TELEGRAM":
                    return new TelegramNotificationService();
                case "WHATSAPP":
                    return new TwilioNotificationService();
                case "SMS":
                    return new SmsNotificationService();
                default:
                    throw new NotSupportedException($"El canal de notificación '{canalPreferido}' no está soportado o es 'Ninguno'.");
            }
        }
    }
}
