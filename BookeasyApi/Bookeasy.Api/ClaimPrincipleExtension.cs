using System.Linq;
using System.Security.Claims;

namespace Bookeasy.Api
{
    public static class ClaimPrincipleExtension
    {
        public static string GetUserId(this ClaimsPrincipal claim)
        {
            return claim.FindFirst("UserId").Value;
        }
    }
}
