using FluentValidation;

namespace Application.Features.Categories.Commands.AddCategory
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.Name)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .WithMessage("Category name is required.")
              .MaximumLength(100);


            RuleFor(_ => _.Description)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
