

using Application.Common;
using MediatR;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<PageResult<GetAllCustomersResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetAllCustomersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
