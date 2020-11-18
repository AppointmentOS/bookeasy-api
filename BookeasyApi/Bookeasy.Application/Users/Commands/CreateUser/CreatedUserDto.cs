using AutoMapper;
using Bookeasy.Application.Common.Mappings;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Users.Commands.CreateUser
{
    public class CreatedUserDto : IMapFrom<User>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatedUserDto, User>();
        }
    }
}