namespace Api.Dto.Product
{
    public record AddProductDto(string Name ,
        string Description,IFormFile ImageUrl,
        decimal Price, int StockQuantity,
        Guid CategoryId);
}
