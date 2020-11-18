using System.Threading;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using MediatR;

namespace Bookeasy.Application.Posts.Commands.DeletePostCommand
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IIrisDbContext _context;

        public DeletePostCommandHandler(IIrisDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            await _context.Post.RemoveAsync(request.PostId);
            return Unit.Value;
        }
    }
}