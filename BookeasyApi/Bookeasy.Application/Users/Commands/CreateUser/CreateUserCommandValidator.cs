using FluentValidation;

namespace Bookeasy.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty().Length(8, 32);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
