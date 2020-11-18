using FluentValidation;

namespace Bookeasy.Api.DTOs
{
    public class NewCommentDto
    {
        /// <summary>
        /// Comment text
        /// </summary>
        /// <value></value>
        public string Body { get; set; }
    }

    public class NewCommentDtoValidators : AbstractValidator<NewCommentDto>
    {
        public NewCommentDtoValidators()
        {
            RuleFor(x => x.Body).NotEmpty();
        }
    }
}