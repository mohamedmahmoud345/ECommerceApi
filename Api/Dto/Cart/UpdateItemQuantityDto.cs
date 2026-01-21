using System;

namespace Api.Dto.Cart
{
    public record UpdateItemQuantityDto(Guid CustomerId,
    Guid ItemId, int quantity);
}
