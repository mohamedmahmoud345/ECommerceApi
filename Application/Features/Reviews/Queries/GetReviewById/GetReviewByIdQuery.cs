using MediatR;

namespace Application.Features.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<GetReviewByIdResponse>
    {
        public GetReviewByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
