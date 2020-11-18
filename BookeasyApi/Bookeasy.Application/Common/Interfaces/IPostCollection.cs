using Bookeasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IPostCollection
    {
        List<Post> Get();
        Task<List<Post>> GetAsync();
        Post Get(string id);
        Task<Post> GetAsync(string id);
        Post Create(Post post);
        Task<Post> CreateAsync(Post post);
        Post Update(string id, Post post);
        Task<Post> UpdateAsync(string id, Post post);
        void Remove(string id);
        Task RemoveAsync(string id);
        Task CreateUpVoteAsync(string postId, string userId);
        Task CreateDownVoteAsync(string postId, string userId);
        Task RemoveVoteAsync(string postId, string userId);
    }
}
