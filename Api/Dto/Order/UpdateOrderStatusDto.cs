using Core.Enums;

namespace Api.Dto.Order
{
    public record UpdateOrderStatusDto
        (Guid OrderId, OrderStatus OrderStatus);
}
