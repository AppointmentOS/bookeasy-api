using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Users.Queries.GetAuthenticationToken
{
    public class GetAuthenticationTokenQuery : Common.Interfaces.IExtendedRequest<AuthenticationTokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}