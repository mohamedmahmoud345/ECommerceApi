using System;
using MediatR;

namespace Application.Features.Payments.Queries.GetPaymentByOrderId
{
    public class GetPaymentByOrderIdQuery : IRequest<GetPaymentByOrderIdResponse>
    {
        public Guid OrderId { get; set; }
        public GetPaymentByOrderIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
