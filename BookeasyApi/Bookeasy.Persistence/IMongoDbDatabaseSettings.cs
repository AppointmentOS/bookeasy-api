namespace Bookeasy.Persistence
{
    public interface IMongoDbDatabaseSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string UserCollection { get; set; }
    }
}
