using System;
using System.Threading;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Enums;
using Bookeasy.Application.Common.Interfaces;
using MediatR;

namespace Bookeasy.Application.Comments.Commands.CreateVoteCommentCommand
{
    public class CreateVoteCommentCommand : IRequest
    {
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string UserId { get; set; }
        public VoteType VoteType { get; set; }
    }

    public class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommentCommand>
    {
        private readonly IIrisDbContext _context;

        public CreateVoteCommandHandler(IIrisDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateVoteCommentCommand request, CancellationToken cancellationToken)
        {
            switch (request.VoteType)
            {
                case VoteType.UpVote:
                    await _context.Comment.CreateUpVoteAsync(request.PostId, request.CommentId, request.UserId);
                    break;
                case VoteType.DownVote:
                    await _context.Comment.CreateDownVoteAsync(request.PostId, request.CommentId, request.UserId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Unit.Value;
        }
    }
}