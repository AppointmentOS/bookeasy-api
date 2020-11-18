using Bookeasy.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Comments.Commands.DeleteCommentCommand
{
    public class DeleteCommentCommand : IRequest
    {
        public string PostId { get; set; }
        public string CommentId { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IIrisDbContext _context;

        public DeleteCommentCommandHandler(IIrisDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            await _context.Comment.RemoveAsync(request.PostId, request.CommentId);
            return Unit.Value;
        }
    }
}
