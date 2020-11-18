namespace Bookeasy.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : Common.Interfaces.IExtendedRequest<UserDto>
    {
        public string UserId { get; set; }

        public GetUserDetailQuery(string userId)
        {
            UserId = userId;
        }
    }
}