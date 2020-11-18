using MediatR;

namespace Bookeasy.Application.Posts.Commands.DeletePostCommand
{
    public class DeletePostCommand : IRequest
    {
        public string PostId { get; set; }
    }
}
