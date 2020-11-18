using Bookeasy.Application.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Bookeasy.Application.Posts.Queries.GetAllPostQuery
{
    public class GetAllPostQuery : IRequest<List<PostDto>>
    {
        public string Id { get; set; }
    }
}
