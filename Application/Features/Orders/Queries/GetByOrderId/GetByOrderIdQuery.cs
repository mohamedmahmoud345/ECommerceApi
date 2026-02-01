using MediatR;

namespace Application.Features.Orders.Queries.GetByOrderId
{
    public class GetByOrderIdQuery : IRequest<GetByOrderIdResponse>
    {
        public Guid Id { get; set; }
        public GetByOrderIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
