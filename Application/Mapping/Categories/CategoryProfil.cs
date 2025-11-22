
using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetCategoryById;
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
        }

    }
}
