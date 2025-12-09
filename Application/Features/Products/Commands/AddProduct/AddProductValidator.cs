using FluentValidation;

namespace Application.Features.Products.Commands.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl is required");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.StockQuantity)
                .NotEmpty().WithMessage("Stock quantity is required")
                .GreaterThan(0).WithMessage("Stock Quantity must be greater than 0");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category id is required");
        }
    }
}