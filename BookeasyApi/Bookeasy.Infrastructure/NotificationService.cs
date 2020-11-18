using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Notifications.Models;

namespace Bookeasy.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}