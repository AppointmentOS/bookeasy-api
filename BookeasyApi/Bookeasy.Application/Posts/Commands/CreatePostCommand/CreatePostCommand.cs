using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Posts.Commands.CreatePostCommand
{
    public class CreatePostCommand : IExtendedRequest<PostDto>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string OwnerUserId { get; set; }
        public string PostType { get; set; }
    }
}
