using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Posts.Queries.GetPostByIdQuery
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public string Id { get; set; }
    }
}
