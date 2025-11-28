using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdQuery : IRequest<List<GetAllReviewsByProductIdResponse>>
    {
        public Guid ProductId { get; set; }

        public GetAllReviewsByProductIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
