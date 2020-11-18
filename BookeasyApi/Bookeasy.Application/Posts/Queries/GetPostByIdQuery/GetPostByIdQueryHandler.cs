using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Posts.Queries.GetPostByIdQuery
{
    public class GetPostByIdQueryHandler : MediatR.IRequestHandler<GetPostByIdQuery, PostDto>
    {
        private readonly IIrisDbContext _context;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IIrisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Post.GetAsync(request.Id);
            return _mapper.Map<PostDto>(post);
        }
    }
}