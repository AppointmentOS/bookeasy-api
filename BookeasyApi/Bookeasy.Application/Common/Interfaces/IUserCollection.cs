using System.Collections.Generic;
using System.Threading.Tasks;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IUserCollection
    {
        List<User> Get();
        User Get(string id);
        Task<User> GetAsync(string id);
        User GetByEmail(string email);
        Task<User> GetByEmailAsync(string email);
        User Create(User newUser);
        Task<User> CreateAsync(User user);
        User Update(string id, User updatedUser);
        void Remove(string id);
        Task RemoveAsync(string id);
    }
}