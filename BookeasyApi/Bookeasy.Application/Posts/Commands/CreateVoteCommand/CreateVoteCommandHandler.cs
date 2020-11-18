using System;
using System.Threading;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Enums;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Posts.Commands.CreateVoteCommand
{
    public class CreateVoteCommandHandler : IExtendedRequestHandler<CreateVoteCommand>
    {
        private readonly IIrisDbContext _context;

        public CreateVoteCommandHandler(IIrisDbContext context)
        {
            _context = context;
        }

        public async Task<CQRSResult<Unit>> Handle(Commands.CreateVoteCommand.CreateVoteCommand request, CancellationToken cancellationToken)
        {
            switch (request.VoteType)
            {
                case VoteType.UpVote:
                    await _context.Post.CreateUpVoteAsync(request.PostId, request.UserId);
                    break;
                case VoteType.DownVote:
                    await _context.Post.CreateDownVoteAsync(request.PostId, request.UserId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return CQRSResult<Unit>.CreateSuccessResult(Unit.Value);
        }
    }
}