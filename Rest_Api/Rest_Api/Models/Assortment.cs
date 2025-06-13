namespace Rest_Api.Models
{
    public class Assortment
    {
        public int Id { get; set; }
        public required string ProductCode { get; set; }
        public string? Name { get; set; }
        public decimal PricePerWeight { get; set; }
    }
}
