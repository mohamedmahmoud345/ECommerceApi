using Core.Enums;

namespace Core.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public PaymentStatus Status { get; private set; }
        public PaymentMethod Method { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid OrderId { get; private set; }
        public Order Order { get; private set; }
        public Payment(Guid orderId, decimal amount, PaymentMethod method, PaymentStatus status, DateTime date)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Id = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Method = method;
            Status = status;
            Date = date;
            CreatedAt = DateTime.UtcNow;
        }
        public void UpdateStatus(PaymentStatus newStatus)
        {
            ValidateStatusTransition(newStatus);
            Status = newStatus;
        }

        private void ValidateStatusTransition(PaymentStatus newStatus)
        {
            // Cannot change from a terminal state
            if (Status == PaymentStatus.Refunded)
                throw new InvalidOperationException("Cannot change status of a refunded payment.");

            // Cannot change Completed payment to Pending
            if (Status == PaymentStatus.Completed && newStatus == PaymentStatus.Pending)
                throw new InvalidOperationException("Cannot revert a completed payment to pending.");

            // Cannot change Failed payment to Pending
            if (Status == PaymentStatus.Failed && newStatus == PaymentStatus.Pending)
                throw new InvalidOperationException("Cannot revert a failed payment to pending.");

            // Can only refund a completed payment
            if (newStatus == PaymentStatus.Refunded && Status != PaymentStatus.Completed)
                throw new InvalidOperationException("Can only refund a completed payment.");
        }

    }
}
