using MediatR;

namespace Bookeasy.Application.Posts.Commands.DeleteVoteCommand
{
    public class DeleteVoteCommand : IRequest
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
    }
}