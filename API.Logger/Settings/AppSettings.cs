namespace API.Logger.Settings
{
    public class AppSettings
    {
        public string? MongoDbUrl { get; }

        public AppSettings(string? mongoDbUrl)
        {
            MongoDbUrl = mongoDbUrl;
        }
    }
}
