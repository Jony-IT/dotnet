using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbBeta.Models
{
    public class Assortment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("productCode")]
        public string ProductCode { get; set; } = null!; 

        [BsonElement("productName")]
        public string ProductName { get; set; } = null!;

        [BsonElement("pricePerWeight")]
        public decimal PricePerWeight { get; set; }
    }

}
