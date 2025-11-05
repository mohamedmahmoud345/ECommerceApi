
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetAllProductsResponse>()
              .ForMember(x => x.CategoryName, src => src.MapFrom(x => x.Category.Name));

            CreateMap<Product, GetProductByIdResponse>()
                .ForMember(x => x.CategoryName, src => src.MapFrom(x => x.Category.Name));
        }
    }
}
