namespace Api.Dto.Cart
{
    public record AddItemDto(Guid CustomerId,
        Guid ProductId, int Quantity);
}
