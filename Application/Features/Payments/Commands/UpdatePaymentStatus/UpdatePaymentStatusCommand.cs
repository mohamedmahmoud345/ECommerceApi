using System;
using Core.Enums;
using MediatR;

namespace Application.Features.Payments.Commands.UpdatePaymentStatus
{
    public class UpdatePaymentStatusCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public UpdatePaymentStatusCommand(Guid id, PaymentStatus paymentStatus)
        {
            Id = id;
            PaymentStatus = paymentStatus;
        }
    }
}
