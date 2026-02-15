using System;
using FluentValidation;

namespace Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderValidator()
        {
            RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum().WithMessage("Invalid payment method");
        }
    }
}
