using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Users.Queries.GetAuthenticationToken
{
    public class GetAuthenticationTokenQueryHandler : MediatR.IRequestHandler<GetAuthenticationTokenQuery, CQRSResult<AuthenticationTokenDto>>
    {
        private readonly IUserManager _userManager;

        public GetAuthenticationTokenQueryHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<CQRSResult<AuthenticationTokenDto>> Handle(GetAuthenticationTokenQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userManager.AuthenticateAsync(new AuthenticationRequest()
                {
                    Email = request.Email,
                    Password = request.Password
                });

                return CQRSResult<AuthenticationTokenDto>.CreateSuccessResult(new AuthenticationTokenDto
                {
                    Token = result.JwtToken,
                    RefreshToken = result.RefreshToken
                });
            }
            catch (Exception e)
            {
                return CQRSResult<AuthenticationTokenDto>.CreateFailureResult(e);
            }
        }
    }
}