using System.Threading;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Notifications.Models;
using MediatR;

namespace Bookeasy.Application.Users.Commands.CreateUser
{
    public class UserCreated : INotification
    {
        public string UserId { get; set; }
        
        public class UserCreatedHandler : INotificationHandler<UserCreated>
        {
            private readonly INotificationService _notification;

            public UserCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }
            public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}