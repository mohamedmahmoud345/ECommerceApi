using Application.Features.Cart.Commands.AddItemToCart;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Carts
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, AddItemToCartResponse>();
        }
    }
}
