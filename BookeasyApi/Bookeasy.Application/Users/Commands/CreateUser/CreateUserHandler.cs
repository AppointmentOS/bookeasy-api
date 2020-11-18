using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using Bookeasy.Application.Users.Queries.GetUserDetail;
using Bookeasy.Domain.Entities;
using MediatR;

namespace Bookeasy.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler : IExtendedRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CQRSResult<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                };
                var createdUser = await _userManager.CreateUserAsync(user, request.Password);
                return CQRSResult<UserDto>.CreateSuccessResult(_mapper.Map<UserDto>(createdUser.user));
            }
            catch (Exception e)
            {
                return CQRSResult<UserDto>.CreateFailureResult(e);
            }
        }
    }
}