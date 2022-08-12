using API.Logger.Entities;
using API.Logger.Settings;
using MongoDB.Driver;

namespace API.Logger.DataStorage
{
    public class MongoDbContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDbContext(AppSettings appSettings)
        {
            var mongoClientSettings = MongoClientSettings.FromConnectionString(appSettings.MongoDbUrl);
            _client = new MongoClient(mongoClientSettings);
            _database = _client.GetDatabase("APILogger");
        }

        public IMongoCollection<Message> GetMessageCollection()
        {
            return _database.GetCollection<Message>("API_Logger_Messages");
        }

    }
}
