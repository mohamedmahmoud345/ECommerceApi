
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdResponse>
    {
        public Guid Id { get; set; }
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
