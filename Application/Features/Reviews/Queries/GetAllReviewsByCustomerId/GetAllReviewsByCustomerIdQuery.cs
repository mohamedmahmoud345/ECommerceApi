using Application.Common;
using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByCustomerId
{
    public class GetAllReviewsByCustomerIdQuery : IRequest<PageResult<GetAllReviewsByCustomerIdResponse>?>
    {
        public Guid CustomerId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public GetAllReviewsByCustomerIdQuery(Guid customerId, int page, int pageSize)
        {
            CustomerId = customerId;
            Page = page;
            PageSize = pageSize;
        }
    }
}
