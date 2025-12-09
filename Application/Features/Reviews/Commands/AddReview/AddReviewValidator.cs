using FluentValidation;

namespace Application.Features.Reviews.Commands.AddReview
{
    public class AddReviewValidator : AbstractValidator<AddReviewCommand>
    {
        public AddReviewValidator()
        {
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment Is Required.")
                .MaximumLength(250).WithMessage("Max Length is 250");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating values between 1 to 5");

        }
    }
}
