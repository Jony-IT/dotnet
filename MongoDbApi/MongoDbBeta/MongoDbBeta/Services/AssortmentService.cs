using MongoDB.Driver;
using MongoDbBeta.Models;

namespace MongoDbBeta.Services
{
    public class AssortmentService
    {
        private readonly IMongoCollection<Assortment> _collection;

        public AssortmentService(MongoDbService dbService)
        {
            _collection = dbService.Assortments;
        }

        public async Task<List<Assortment>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Assortment?> GetByIdAsync(string id) =>
            await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Assortment item) =>
            await _collection.InsertOneAsync(item);

        public async Task UpdateAsync(string id, Assortment updatedItem) =>
            await _collection.ReplaceOneAsync(a => a.Id == id, updatedItem);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(a => a.Id == id);
    }

}
