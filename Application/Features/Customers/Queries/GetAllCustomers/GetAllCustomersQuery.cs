

using MediatR;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<GetAllCustomersResponse>>
    {
    }
}
