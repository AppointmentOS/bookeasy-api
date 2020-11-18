using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly IIrisDbContext _context;
        private readonly IAuthenticationTokenGenerator _authenticationTokenGenerator;

        public UserManagerService(IIrisDbContext context, IAuthenticationTokenGenerator authenticationTokenGenerator)
        {
            _context = context;
            _authenticationTokenGenerator = authenticationTokenGenerator;
        }

        public async Task<(Result Result, User user)> CreateUserAsync(User user, string password)
        {
            // check for existing user
            var foundUser = await _context.User.GetByEmailAsync(user.Email);
            if (foundUser == null)
            {
                var salt = PasswordHasherUtility.CreateSalt();
                user.PasswordSalt = salt;
                user.PasswordHash = PasswordHasherUtility.HashPassword(password, salt);
                var createdUser = await _context.User.CreateAsync(user);
                return (Result.Success(), createdUser);
            }
            throw new InvalidOperationException("User already exists");
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var foundUser = await _context.User.GetAsync(userId);
            if (foundUser == null)
                throw new InvalidOperationException("User not found");
            await _context.User.RemoveAsync(userId);
            return Result.Success();
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _context.User.GetByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("User not found");
            var isValid = PasswordHasherUtility.VerifyPassword(request.Password, user.PasswordSalt, user.PasswordHash);
            if (isValid)
                return new AuthenticationResponse
                {
                    Email = user.Email,
                    JwtToken = _authenticationTokenGenerator.GenerateToken(new List<Claim>
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    RefreshToken = _authenticationTokenGenerator.GenerateRefreshToken(user.Email).Token
                };

            throw new AuthenticationException("Invalid email or password");
        }
    }
}