using MediatR;

namespace Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public int? Rating { get; set; }
    }
}
