using Bookeasy.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Posts.Commands.DeleteVoteCommand
{
    public class DeleteVoteCommandHandler : IRequestHandler<DeleteVoteCommand>
    {
        private readonly IIrisDbContext _context;

        public DeleteVoteCommandHandler(IIrisDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Commands.DeleteVoteCommand.DeleteVoteCommand request,
            CancellationToken cancellationToken)
        {
            await _context.Post.RemoveVoteAsync(request.PostId, request.UserId);
            return Unit.Value;
        }
    }
}