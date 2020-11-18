using AutoMapper;
using Bookeasy.Application.Common.Mappings;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Users.Queries.GetUserDetail
{
    public class UserDto : IMapFrom<User>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id.ToString()));
            profile.CreateMap<UserDto, User>();
        }
    }
}
