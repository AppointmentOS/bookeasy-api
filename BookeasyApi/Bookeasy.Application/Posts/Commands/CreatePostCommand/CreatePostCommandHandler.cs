using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Posts.Commands.CreatePostCommand
{
    public class CreatePostCommandHandler : IExtendedRequestHandler<CreatePostCommand, PostDto>
    {
        private readonly IIrisDbContext _context;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IIrisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CQRSResult<PostDto>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.OwnerUserId))
                return CQRSResult<PostDto>.CreateFailureResult(new Exception("OwnerId is missing"));

            var post = new Post
            {
                Title = request.Title,
                OwnerId = request.OwnerUserId,
                Body = request.Body
            };
            var newPost = await _context.Post.CreateAsync(post);
            return CQRSResult<PostDto>.CreateSuccessResult(_mapper.Map<PostDto>(newPost));
        }
    }
}