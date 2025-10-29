using Core.Entities;

namespace Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
