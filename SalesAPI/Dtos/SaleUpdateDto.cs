using SalesAPI.Models;

namespace SalesAPI.Dtos
{
    public class SaleUpdateDto
    {
        public int CustomerId { get; set; }
        public int SalesRepId { get; set; }
        public DateTime SaleDate { get; set; }

        public List<SaleItemDto> SaleItems { get; set; } = new();
    }
}
