using Bookeasy.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
