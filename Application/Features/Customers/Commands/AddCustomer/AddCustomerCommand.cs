
using MediatR;

namespace Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerCommand : IRequest<AddCustomerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
