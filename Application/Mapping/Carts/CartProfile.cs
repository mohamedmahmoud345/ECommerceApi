using Application.Features.Cart.Commands.AddItemToCart;
using Application.Features.Cart.Common;
using Application.Features.Cart.Queries.GetAllCartItemsByCustomerId;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Carts
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, AddItemToCartResponse>()
                .ForMember(x => x.TotalItems, x => x.MapFrom(x => x.Quantity))
                .ForMember(x => x.Items, x => x.MapFrom(x => x.Items));

            CreateMap<Cart, GetAllCartItemsByCustomerIdResponse>()
                .ForMember(x => x.TotalItems, x => x.MapFrom(x => x.Quantity))
                .ForMember(x => x.Items, x => x.MapFrom(x => x.Items));

            CreateMap<CartItem, CartItemResponse>()
                .ForMember(x => x.ProductName, x => x.MapFrom(x => x.Product.Name))
                .ForMember(x => x.ProductImageUrl, x => x.MapFrom(x => x.Product.ImageUrl))
                .ForMember(x => x.ProductPrice, x => x.MapFrom(x => x.Product.Price))
                .ForMember(x => x.SubTotal, x => x.MapFrom(x => x.Product.Price * x.Quantity));
        }
    }
}
