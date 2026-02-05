using System;
using Core.Enums;
using FluentValidation;

namespace Application.Features.Orders.Commands.RefundOrder
{
    public class RefundOrderValidation : AbstractValidator<RefundOrderCommand>
    {
        public RefundOrderValidation()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("Order id is required");
        }
    }
}
