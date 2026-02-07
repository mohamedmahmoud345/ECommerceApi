using Core.Enums;

namespace Api.Dto.Payment
{
    public record UpdatePaymentStatusDto(Guid id, PaymentStatus PaymentStatus);
}
