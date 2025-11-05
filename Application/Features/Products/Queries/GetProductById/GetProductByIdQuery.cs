
using MediatR;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdResponse>
    {
        public Guid Id { get; init; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
