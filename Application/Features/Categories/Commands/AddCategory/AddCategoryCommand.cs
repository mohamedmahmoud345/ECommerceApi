using MediatR;

namespace Application.Features.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<AddCategoryResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
