using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;
using FluentValidation;
using MediatR;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Comments.Commands.UpdateCommentCommand
{
    public class UpdateCommentCommand : MediatR.IRequest<Comment>
    {
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string OwnerUserId { get; set; }
        public string Body { get; set; }
    }

    public class UpdateCommentCommandHandler : MediatR.IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly IIrisDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IIrisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Comment.UpdateAsync(request.PostId,
                new Comment
                {
                    Id = ObjectId.Parse(request.CommentId),
                    Body = request.Body,
                    OwnerUserId = request.OwnerUserId
                });

            return _mapper.Map<Comment>(result);
        }
    }

    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(x => x.CommentId).NotEmpty();
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.OwnerUserId).NotEmpty();
            RuleFor(x => x.Body).NotEmpty();
        }
    }
}