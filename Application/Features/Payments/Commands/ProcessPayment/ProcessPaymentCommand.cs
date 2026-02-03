using System;
using Core.Enums;
using MediatR;

namespace Application.Features.Payments.Commands.ProcessPayment
{
    public class ProcessPaymentCommand : IRequest<ProcessPaymentResponse>
    {
        public Guid OrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ProcessPaymentCommand
        (Guid orderId, PaymentMethod paymentMethod)
        {
            OrderId = orderId;
            PaymentMethod = paymentMethod;
        }
    }
}
