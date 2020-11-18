using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Notifications.Models;
using System.Threading.Tasks;

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