namespace MiniMarketBackEnd.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public short SupplierId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Measure { get; set; }
        public decimal Price { get; set; }
        virtual public Stock Stock { get; set; }
        virtual public Supplier Supplier { get; set; }
        virtual public Category Category { get; set; }

    }
}
