using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Comments.Commands.CreateCommentCommand
{
    public class
        CreateCommentCommandHandler : MediatR.IRequestHandler<Commands.CreateCommentCommand.CreateCommentCommand,
            Comment>
    {
        private readonly IIrisDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IIrisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.OwnerUserId))
                throw new ArgumentException(nameof(request.OwnerUserId) + " is required");

            if (string.IsNullOrEmpty(request.PostId))
                throw new ArgumentException(nameof(request.PostId) + " is required");

            var newComment = await _context.Comment.AddAsync(request.PostId,
                new Comment { Body = request.Body, CreationDate = DateTime.Now, OwnerUserId = request.OwnerUserId });

            return _mapper.Map<Comment>(newComment);
        }
    }
}