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
        public Guid? AdminId { get; private set; }
        public Admin? Admin { get; private set; }
        public Payment(Guid orderId, decimal amount, PaymentMethod method, PaymentStatus status, DateTime date, Guid? adminId = null)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Id = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Method = method;
            Status = status;
            Date = date;
            AdminId = adminId;
            CreatedAt = DateTime.UtcNow;
        }
        public void UpdateStatus(PaymentStatus newStatus)
        {
            Status = newStatus;
        }

        public void AssignAdmin(Guid adminId)
        {
            AdminId = adminId;
        }
    }
}
