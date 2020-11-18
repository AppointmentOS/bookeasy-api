using Bookeasy.Api.DTOs;
using Bookeasy.Application.Users.Commands.CreateUser;
using Bookeasy.Application.Users.Queries.GetUserDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bookeasy.Api.Controllers
{
    public class UsersController : BaseController
    {
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateNewUser(NewUserDto newUser)
        {
            var result = await Mediator.Send(new CreateUserCommand
            {
                Email = newUser.Email,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName
            });
            if (result.Success)
                return Ok(result.Payload);
            return BadRequest(new ProblemDetails()
            {
                Detail = result.Error.Message,
                Title = result.Error.GetType().Name
            });
        }
    }
}