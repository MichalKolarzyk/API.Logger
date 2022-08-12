using API.Logger.DataStorage;
using MongoDB.Driver;

namespace API.Logger.Settings
{
    public static class ServicesCollectionExtensions
    {

        public static void AddAppSettings(this IServiceCollection services)
        {
            var appSettings = new AppSettings(
                mongoDbUrl: Environment.GetEnvironmentVariable("MONGODB_URL") ?? ""
            );

            services.AddSingleton(appSettings);
        }

        public static void AddDbClients(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();
        }
    }
}
