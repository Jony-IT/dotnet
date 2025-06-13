using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbBeta.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("customer")]
        public string Customer { get; set; } = null!;

        [BsonElement("productCode")]
        public string ProductCode { get; set; } = null!;

        [BsonElement("productName")]
        public string ProductName { get; set; } = null!;

        [BsonElement("weight")]
        public decimal Weight { get; set; }

        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }

        [BsonElement("orderCost")]
        public decimal OrderCost { get; set; }
    }
}
