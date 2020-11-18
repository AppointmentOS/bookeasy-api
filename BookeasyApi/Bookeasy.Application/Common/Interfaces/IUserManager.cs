using System.Threading.Tasks;
using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, User user)> CreateUserAsync(User user, string password);

        Task<Result> DeleteUserAsync(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Token and refresh token</returns>
        /// <exception cref="AuthenticationException">Email or password mismatch</exception>
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    }
}