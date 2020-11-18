using FluentValidation;

namespace Bookeasy.Application.Posts.Commands.UpdatePostCommand
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(10);
            RuleFor(x => x.Body).NotEmpty().MinimumLength(10);
        }
    }
}