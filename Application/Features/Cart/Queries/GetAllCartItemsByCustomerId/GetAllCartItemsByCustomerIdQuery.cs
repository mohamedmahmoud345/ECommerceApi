using MediatR;

namespace Application.Features.Cart.Queries.GetAllCartItemsByCustomerId
{
    public class GetAllCartItemsByCustomerIdQuery : IRequest<GetAllCartItemsByCustomerIdResponse>
    {
        public Guid CustomerId { get; set; }
        public GetAllCartItemsByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;

        }
    }
}
