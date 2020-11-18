using Bookeasy.Application.Common.Enums;
using Bookeasy.Application.Common.Interfaces;
using MediatR;

namespace Bookeasy.Application.Posts.Commands.CreateVoteCommand
{
    public class CreateVoteCommand : IExtendedRequest
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public VoteType VoteType { get; set; }
    }
}