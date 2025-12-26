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

            RuleFor(x => x.ImageName)
                .Must(BeValidImageExtension).WithMessage("Only .jpg or .png allowed");

            RuleFor(x => x.ImageStream)
                .Must(stream => stream.Length <= 5 * 1024 * 1024)
                .WithMessage("File size must not exceed 5MB");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.StockQuantity)
                .NotEmpty().WithMessage("Stock quantity is required")
                .GreaterThan(0).WithMessage("Stock Quantity must be greater than 0");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category id is required");
        }

        private bool BeValidImageExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();

            return extension == ".jpg" || extension == ".png";
        }
    }
}