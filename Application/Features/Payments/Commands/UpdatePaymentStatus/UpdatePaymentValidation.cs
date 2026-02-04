using System;
using Core.Enums;
using FluentValidation;

namespace Application.Features.Payments.Commands.UpdatePaymentStatus
{
    public class UpdatePaymentStatusValidation : AbstractValidator<UpdatePaymentStatusCommand>
    {
        public UpdatePaymentStatusValidation()
        {
            RuleFor(x => x.PaymentStatus)
                .NotEmpty().WithMessage("Status is required")
                .Must(BeValidPaymentStatus).WithMessage("Invalid Value");
        }
        private bool BeValidPaymentStatus(PaymentStatus paymentStatus)
        {
            if (paymentStatus == null)
                return true;
            return paymentStatus == PaymentStatus.Completed ||
                paymentStatus == PaymentStatus.Pending ||
                paymentStatus == PaymentStatus.Refunded ||
                paymentStatus == PaymentStatus.Failed;
        }
    }
}
