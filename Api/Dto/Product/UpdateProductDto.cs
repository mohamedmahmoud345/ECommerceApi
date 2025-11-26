namespace Api.Dto.Product
{
    public record UpdateProductDto(Guid Id, string? Name,
        string? Description, IFormFile? ImageUrl,
        decimal? Price, int? StockQuantity,
        Guid? CategoryId);
}
