using MongoDB.Driver;
using MongoDbBeta.Models;

namespace MongoDbBeta.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderService(MongoDbService dbService)
        {
            _collection = dbService.Orders;
        }

        public async Task<List<Order>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Order?> GetByIdAsync(string id) =>
            await _collection.Find(o => o.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Order item) =>
            await _collection.InsertOneAsync(item);

        public async Task UpdateAsync(string id, Order updatedItem) =>
            await _collection.ReplaceOneAsync(o => o.Id == id, updatedItem);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(o => o.Id == id);

        // Дополнительный метод: получить заказы по дате исполнения
        public async Task<List<Order>> GetByOrderDateAsync(DateTime date) =>
            await _collection.Find(o => o.OrderDate.Date == date.Date).ToListAsync();
    }
}
