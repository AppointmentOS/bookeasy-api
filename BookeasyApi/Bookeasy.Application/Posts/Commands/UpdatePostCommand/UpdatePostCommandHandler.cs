using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Posts.Commands.UpdatePostCommand
{
    public class UpdatePostCommandHandler : MediatR.IRequestHandler<UpdatePostCommand, PostDto>
    {
        private readonly IIrisDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IIrisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var newPost = await _context.Post.UpdateAsync(request.PostId, new Post() { Body = request.Body });
            return _mapper.Map<PostDto>(newPost);
        }
    }
}
