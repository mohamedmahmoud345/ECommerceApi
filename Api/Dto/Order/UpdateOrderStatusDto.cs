using Core.Enums;

namespace Api.Dto.Order
{
    public record class UpdateOrderStatusDto
        (Guid OrderId, OrderStatus OrderStatus);
}
