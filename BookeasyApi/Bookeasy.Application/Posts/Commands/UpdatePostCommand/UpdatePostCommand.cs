using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Posts.Commands.UpdatePostCommand
{
    public class UpdatePostCommand : IRequest<PostDto>
    {
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}