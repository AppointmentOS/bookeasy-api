using System.Collections.Generic;
using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Posts.Queries.GetAllPostQuery
{
    public class GetAllPostQuery : IRequest<List<PostDto>>
    {
        public string Id { get; set; }
    }
}