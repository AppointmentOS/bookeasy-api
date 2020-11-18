using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Users.Queries.GetUserDetail;
using MediatR;

namespace Bookeasy.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IExtendedRequest<UserDto>
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
