using API.Logger.DataStorage;
using API.Logger.MIddlewares;
using MongoDB.Driver;

namespace API.Logger.Settings
{
    public static class ServicesCollectionExtensions
    {

        public static void AddAppSettings(this IServiceCollection services)
        {
            var appSettings = new AppSettings(
                mongoDbUrl: Environment.GetEnvironmentVariable("MONGODB_URL") ?? "mongodb://localhost:27017"
            );

            services.AddSingleton(appSettings);
        }

        public static void AddDbClients(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();
        }

        public static void AddCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHeandlingMiddelware>();
        }

        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Constans.CustomCorsPolicy.AllowAll, policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                });
            });
        }
    }
}
