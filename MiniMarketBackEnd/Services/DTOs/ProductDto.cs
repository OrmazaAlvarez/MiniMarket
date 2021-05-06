namespace MiniMarketBackEnd.Services.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public short SupplierId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Measure { get; set; }
        public decimal Price { get; set; }
    }
}
