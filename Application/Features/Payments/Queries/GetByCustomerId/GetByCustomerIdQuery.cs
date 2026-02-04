using System;
using MediatR;

namespace Application.Features.Payments.Queries.GetByCustomerId
{
    public class GetByCustomerIdQuery : IRequest<GetByCustomerIdResponse>
    {
        public Guid CustomerId { get; set; }
        public GetByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
