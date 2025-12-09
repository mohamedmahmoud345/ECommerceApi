
using Application.Common;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery: IRequest<PageResult<GetAllProductsResponse?>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetAllProductsQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
