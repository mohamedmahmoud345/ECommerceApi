using FluentValidation;

namespace Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress();

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .Matches("^01[0-2,5]\\d{8}$");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(50).WithMessage("Address must not exceed 50 characters");
        }
    }
}
