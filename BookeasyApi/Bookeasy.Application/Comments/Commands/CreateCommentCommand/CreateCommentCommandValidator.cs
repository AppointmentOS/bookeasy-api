using Bookeasy.Application.Posts.Commands.CreatePostCommand;
using FluentValidation;

namespace Bookeasy.Application.Comments.Commands.CreateCommentCommand
{
    public class CreateCommentCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Body).NotEmpty();
        }
    }
}
