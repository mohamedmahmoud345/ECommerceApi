using Core.Enums;

namespace Api.Dto.Payment
{
    public record class UpdatePaymentStatusDto(Guid id, PaymentStatus PaymentStatus);
}
