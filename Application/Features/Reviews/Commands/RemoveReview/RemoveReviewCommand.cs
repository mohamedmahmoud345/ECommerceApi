using MediatR;

namespace Application.Features.Reviews.Commands.RemoveReview
{
    public class RemoveReviewCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public RemoveReviewCommand(Guid id)
        {
            Id = id;
        }
    }
}
