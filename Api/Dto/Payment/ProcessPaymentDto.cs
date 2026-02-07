using Core.Enums;

namespace Api.Dto.Payment
{
    public record ProcessPaymentDto
    (Guid OrderId, PaymentMethod PaymentMethod);
}
