using Bookeasy.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Bookeasy.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIrisDbContext>(provider =>
            {
                var clientSetting =
                    MongoClientSettings.FromConnectionString(configuration["MongoDb:ConnectionString"]);
                clientSetting.RetryWrites = false;
                var client = new MongoClient(clientSetting);
                try
                {
                    client.ListDatabaseNames();
                }
                catch (System.Exception)
                {
                    throw new System.Exception("Cannot connect to mongoDb");
                }
                return new IrisDbContext(client);
            });
            
            return services;
        }
    }
}