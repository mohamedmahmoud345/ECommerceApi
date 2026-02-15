using FluentValidation;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

            RuleFor(x => x.Phone)
                .Matches("^01[0-2,5]\\d{8}$");

            RuleFor(x => x.Address)
                .MaximumLength(50).WithMessage("Address must not exceed 50 characters");
        }
    }
}
