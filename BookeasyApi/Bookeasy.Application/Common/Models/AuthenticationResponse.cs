using System.Text.Json.Serialization;

namespace Bookeasy.Application.Common.Models
{
    public class AuthenticationResponse
    {
        public string Email { get; set; }
        public string JwtToken { get; set; }
        [JsonIgnore] public string RefreshToken { get; set; }
    }
}
