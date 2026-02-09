using Core.Enums;

namespace Application.Features.Payments.Commands.ProcessPayment
{
    public class ProcessPaymentResponse
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public PaymentStatus Status { get; private set; }
        public PaymentMethod Method { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid OrderId { get; private set; }
    }
}
