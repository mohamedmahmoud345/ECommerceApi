using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrdersByCustomerId
{
    public class GetAllOrdersByCustomerIdQuery : IRequest<GetAllOrdersByCustomerIdResponse>
    {
        public Guid CustomerId { get; set; }

        public GetAllOrdersByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
