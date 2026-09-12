namespace SalesAPI.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SalesRepId { get; set; }
        public DateTime SaleDate { get; set; }

        public List<SaleItem> SaleItems { get; set; } = new();

        public required Customer Customer { get; set; }
        public required SalesRep SalesRep { get; set; }
    }
}
