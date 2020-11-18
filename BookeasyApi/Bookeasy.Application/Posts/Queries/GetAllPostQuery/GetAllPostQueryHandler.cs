using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Posts.Queries.GetAllPostQuery
{
    public class GetAllPostQueryHandler : MediatR.IRequestHandler<GetAllPostQuery, List<PostDto>>
    {
        private readonly IIrisDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllPostQueryHandler(IIrisDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var posts = await _dbContext.Post.GetAsync();

            return _mapper.Map<List<PostDto>>(posts.ToList());
        }
    }
}
