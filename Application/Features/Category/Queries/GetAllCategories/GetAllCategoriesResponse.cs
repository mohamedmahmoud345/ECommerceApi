

namespace Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
