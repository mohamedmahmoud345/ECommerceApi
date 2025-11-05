
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery: IRequest<List<GetAllProductsResponse>>
    {
    }
}
