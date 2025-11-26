
using Application.Features.Categories.Commands.AddCategory;
using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Queries.GetCategoryById;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Categories
{
    public class CategoryProfil : Profile
    {
        public CategoryProfil()
        {
            CreateMap<Category, GetAllCategoriesResponse>();

            CreateMap<Category, GetCategoryByIdResponse>();

            CreateMap<Category, AddCategoryResponse>();
        }

    }
}
