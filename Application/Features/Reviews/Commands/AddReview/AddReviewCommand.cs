using MediatR;

namespace Application.Features.Reviews.Commands.AddReview
{
    public class AddReviewCommand : IRequest<AddReviewResponse>
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
