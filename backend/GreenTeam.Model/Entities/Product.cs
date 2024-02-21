
namespace GreenTeam.Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ChequeProduct>? ChequeProducts { get; set; }
    }
}
