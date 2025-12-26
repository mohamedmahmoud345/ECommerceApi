using FluentValidation;

namespace Application.Features.Products.Commands.UpdateProductImage
{
    public class UpdateProductImageValidator : AbstractValidator<UpdateProductImageCommand>
    {
        public UpdateProductImageValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");

            RuleFor(x => x.ImageName)
                .Must(BeValidImageExtension)
                .WithMessage("Only .jpg or .png allowed");

            RuleFor(x => x.ImageStream)
                .Must(stream => stream.Length <= 5 * 1024 * 1024)
                .WithMessage("File size must not exceed 5MB");
        }

        private bool BeValidImageExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            return extension == ".jpg" || extension == ".png";
        }
    }
}
