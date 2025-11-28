using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByCustomerId
{
    public class GetAllReviewsByCustomerIdQuery : IRequest<List<GetAllReviewsByCustomerIdResponse>?>
    {
        public Guid CustomerId { get; set; }

        public GetAllReviewsByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
