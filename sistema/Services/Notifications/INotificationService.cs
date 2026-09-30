using sistema.Models;
using System.Threading.Tasks;

namespace sistema.Services.Notifications
{
    public interface INotificationService
    {
        Task<bool> EnviarNotificacionAsync(Paciente paciente, string mensaje);
    }
}
