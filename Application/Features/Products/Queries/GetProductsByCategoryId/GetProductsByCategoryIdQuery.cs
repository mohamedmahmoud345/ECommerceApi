using MediatR;

namespace Application.Features.Products.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQuery : IRequest<List<GetProductsByCategoryIdResponse>>
    {
        public Guid Id { get; init; }

        public GetProductsByCategoryIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
