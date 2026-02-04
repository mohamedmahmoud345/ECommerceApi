using System;
using Core.Enums;

namespace Application.Features.Payments.Queries.GetById
{
    public class GetByIdResponse
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
