using Core.Enums;

namespace Api.Dto.Payment;

public record class ProcessPaymentDto
(Guid OrderId, PaymentMethod PaymentMethod);
