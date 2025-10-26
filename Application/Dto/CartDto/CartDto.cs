

using Core.Entities;

namespace Application.Dto.CartDto
{
    public class CartDto
    {
        public Guid Id { get;  set; }
        public DateTime Date { get;  set; }
        public Guid CustomerId { get;  set; }
        public Customer Customer { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
