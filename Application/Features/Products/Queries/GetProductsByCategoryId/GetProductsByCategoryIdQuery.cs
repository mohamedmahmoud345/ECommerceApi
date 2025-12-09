using Application.Common;
using MediatR;

namespace Application.Features.Products.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQuery : IRequest<PageResult<GetProductsByCategoryIdResponse?>>
    {
        public Guid Id { get; init; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public GetProductsByCategoryIdQuery(Guid id , int page, int pageSize)
        {
            Id = id;
            Page = page;
            PageSize = pageSize;
        }
    }
}
