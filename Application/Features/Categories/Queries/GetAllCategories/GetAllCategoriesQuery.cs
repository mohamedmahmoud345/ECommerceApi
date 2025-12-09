

using Application.Common;
using MediatR;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<PageResult<GetAllCategoriesResponse>>
    {
        public GetAllCategoriesQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
