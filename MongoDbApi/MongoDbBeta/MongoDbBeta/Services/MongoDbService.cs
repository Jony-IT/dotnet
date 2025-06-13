using MongoDB.Driver;
using MongoDbBeta.Models;

namespace MongoDbBeta.Services
{

    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("OrrdersDb");
        }

        public IMongoCollection<Assortment> Assortments => _database.GetCollection<Assortment>("Assortments");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
    }
}
