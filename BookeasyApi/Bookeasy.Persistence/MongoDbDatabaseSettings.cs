namespace Bookeasy.Persistence
{
    public class MongoDbDatabaseSettings : IMongoDbDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string UserCollection { get; set; }
    }
}