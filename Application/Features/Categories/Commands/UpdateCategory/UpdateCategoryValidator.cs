using FluentValidation;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .When(x => x.Name != null);

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Max Length is 250")
                .When(x => x.Description != null);

        }
    }
}
