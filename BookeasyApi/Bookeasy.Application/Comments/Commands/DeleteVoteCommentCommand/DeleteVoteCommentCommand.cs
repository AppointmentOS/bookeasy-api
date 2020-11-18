using System.Threading;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using MediatR;

namespace Bookeasy.Application.Comments.Commands.DeleteVoteCommentCommand
{
    public class DeleteVoteCommentCommand : IRequest
    {
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteVoteCommentCommandHandler : IRequestHandler<DeleteVoteCommentCommand>
    {
        private readonly IIrisDbContext _context;

        public DeleteVoteCommentCommandHandler(IIrisDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(DeleteVoteCommentCommand request, CancellationToken cancellationToken)
        {
            await _context.Comment.RemoveVoteAsync(request.PostId, request.CommentId, request.UserId);
            return Unit.Value;
        }
    }
}