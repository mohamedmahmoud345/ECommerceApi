using FluentValidation;

namespace Application.Features.Cart.Commands.AddItemToCart
{
    public class AddItemToCartValidator : AbstractValidator<AddItemToCartCommand>
    {
        public AddItemToCartValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer Id is required");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity can't be negative");
        }
    }
}