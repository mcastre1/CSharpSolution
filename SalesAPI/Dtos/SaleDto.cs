namespace SalesAPI.Models
{
    public class SaleDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SalesRepId { get; set; }
        public DateTime SaleDate { get; set; }

        public List<SaleItemDto> SaleItems { get; set; } = new();
    }
}
