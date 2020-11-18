using Bookeasy.Domain.Entities;
using MongoDB.Driver;

namespace Bookeasy.Data.Services
{
    public abstract class CollectionBase<T>
    {
        protected readonly IMongoCollection<T> Collection;

        protected CollectionBase(IMongoCollection<T> collection)
        {
            Collection = collection;
        }
    }
}
