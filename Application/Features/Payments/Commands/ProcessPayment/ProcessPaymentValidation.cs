using System;
using System.Security.Cryptography.X509Certificates;
using Core.Enums;
using FluentValidation;

namespace Application.Features.Payments.Commands.ProcessPayment
{
    public class ProcessPaymentValidation : AbstractValidator<ProcessPaymentCommand>
    {
        public ProcessPaymentValidation()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("Order id is required");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required")
                .Must(BeValidPaymentMethod).WithMessage("Payment method should be CreditCard or PayPal");

        }

        private bool BeValidPaymentMethod(PaymentMethod paymentMethod)
        {
            return paymentMethod == PaymentMethod.CreditCard ||
                paymentMethod == PaymentMethod.PayPal;
        }
    }
}
