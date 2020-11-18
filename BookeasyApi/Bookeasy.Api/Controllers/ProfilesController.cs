using Bookeasy.Api.DTOs;
using Bookeasy.Application.Users.Queries.GetUserDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookeasy.Api.Controllers
{
    public class ProfilesController : BaseController
    {
        /// <summary>
        /// Get public profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        [Route("public/{profileId}")]
        [HttpGet]
        [ProducesResponseType(typeof(PublicProfileDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicProfile([FromRoute] string profileId)
        {
            var user = await Mediator.Send(new GetUserDetailQuery(profileId));
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        /// <summary>
        /// Get private profile
        /// </summary>
        /// <returns></returns>
        [Route("private/{profileId}")]
        [HttpGet]
        [ProducesResponseType(typeof(PrivateProfileDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPrivateProfile()
        {
            var user = await Mediator.Send(new GetUserDetailQuery(User.GetUserId()));
            if (user != null)
                return Ok(user);
            return NotFound();
        }
    }
}
