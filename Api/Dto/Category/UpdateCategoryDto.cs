namespace Api.Dto.Category
{
    public record UpdateCategoryDto(Guid Id,
        string? Name, string? Description);
}
