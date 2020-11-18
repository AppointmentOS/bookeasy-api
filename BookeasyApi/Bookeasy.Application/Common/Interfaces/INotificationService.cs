using System.Threading.Tasks;
using Bookeasy.Application.Notifications.Models;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}