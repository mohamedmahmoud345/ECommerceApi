using Application.Common;
using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdQuery : IRequest<PageResult<GetAllReviewsByProductIdResponse>>
    {
        public GetAllReviewsByProductIdQuery(Guid productId, int page, int pageSize)
        {
            ProductId = productId;
            Page = page;
            PageSize = pageSize;
        }

        public Guid ProductId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
