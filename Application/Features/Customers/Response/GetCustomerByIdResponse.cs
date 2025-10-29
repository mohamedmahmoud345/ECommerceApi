
using Core.Entities;

namespace Application.Features.Customers.Response
{
    public class GetCustomerByIdResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

    }
}
