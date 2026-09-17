namespace SalesAPI.Dtos
{
    public class ProductCreateDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}
