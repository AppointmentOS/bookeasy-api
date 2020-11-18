using System.Collections.Generic;
using System.Threading.Tasks;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface ICommentCollection
    {
        List<Comment> GetByPostId(string postId);
        Comment Get(string commentId);
        Comment Add(string postId, Comment comment);
        Task<Comment> AddAsync(string postId, Comment comment);
        Comment Update(string commentId, Comment comment);
        Task<Comment> UpdateAsync(string postId, Comment comment);
        void Remove(string postId, string commentId);
        Task RemoveAsync(string postId, string commentId);
        Task CreateUpVoteAsync(string postId, string commentId, string userId);
        Task CreateDownVoteAsync(string postId, string commentId, string userId);
        Task RemoveVoteAsync(string postId, string commentId, string userId);
    }
}