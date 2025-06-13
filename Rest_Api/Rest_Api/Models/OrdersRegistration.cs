namespace Rest_Api.Models
{
    public class OrdersRegistration
    {
        public int Id { get; set; }
        public required string Customer { get; set; } 
        public required string ProductCode { get; set; } 
        public string? ProductName { get; set; } 
        public decimal Weight { get; set; } 
        public DateTime OrderDate { get; set; }
        public decimal OrderCost { get; set; } 
    }
}
