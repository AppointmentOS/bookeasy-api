using System;
using FluentValidation;
using Bookeasy.Application.Common.Enums;

namespace Bookeasy.Application.Posts.Commands.CreateVoteCommand
{
    public class CreateVoteDtoValidator : AbstractValidator<CreateVoteDto>
    {
        public CreateVoteDtoValidator()
        {
            RuleFor(x => x.VoteType).Must(s => Enum.TryParse(typeof(VoteType), s, true, out var _));
        }
    }
}