using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;
using MediatR;

namespace Bookeasy.Application.Comments.Commands.CreateCommentCommand
{
    public class CreateCommentCommand : IRequest<Comment>
    {
        public string PostId { get; set; }
        public string OwnerUserId { get; set; }
        public string Body { get; set; }
    }
}
