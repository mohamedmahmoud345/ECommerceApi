using FluentValidation;

namespace Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.Comment)
                .MaximumLength(250).WithMessage("Max Length is 250");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating values between 1 to 5");

        }
    }
}
