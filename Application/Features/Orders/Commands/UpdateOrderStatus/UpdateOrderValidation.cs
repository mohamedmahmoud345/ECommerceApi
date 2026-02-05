using System;
using Core.Enums;
using FluentValidation;

namespace Application.Features.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderValidation : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderValidation()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("Order id is required");

            RuleFor(x => x.OrderStatus)
                .Must(IsAValidStatus).WithMessage("Status can only change to shipped or delivered.");
        }

        private bool IsAValidStatus(OrderStatus orderStatus)
            => orderStatus == OrderStatus.Shipped || orderStatus == OrderStatus.Delivered;
    }
}
