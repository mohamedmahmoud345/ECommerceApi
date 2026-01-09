namespace Api.Dto.Cart;

public record class DeleteItemDto(Guid CustomerId, Guid ItemId);
