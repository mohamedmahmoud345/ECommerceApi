namespace Api.Dto.Product
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
