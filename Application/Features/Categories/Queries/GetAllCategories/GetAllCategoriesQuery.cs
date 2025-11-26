

using MediatR;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<GetAllCategoriesResponse>>
    {
    }
}
