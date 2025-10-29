
using MediatR;

namespace Application.Features.Customers.Queries.GetCustomerByEmail
{
    public class GetCustomerByEmailQuery : IRequest<GetCustomerByEmailResponse>
    {
        public string Email { get; set; }

        public GetCustomerByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
