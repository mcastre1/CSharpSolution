using SalesAPI.Models;

namespace SalesAPI.Dtos
{
    public class SaleCreateDto
    {
        public int CustomerId { get; set; }
        public int SalesRepId { get; set; }
        public DateTime SaleDate { get; set; }

        public List<SaleItemDto> SaleItems { get; set; } = new();
    }
}
