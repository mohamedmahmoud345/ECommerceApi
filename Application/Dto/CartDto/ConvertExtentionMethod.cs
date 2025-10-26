
using Core.Entities;

namespace Application.Dto.CartDto
{
    public static class ConvertExtentionMethod
    {
        public static CartDto ToDto(this Cart cart)
        {
            var cartDto = new CartDto()
            {
                Id = cart.Id,
                Date = cart.Date,
                CreatedAt = cart.CreatedAt,
                Customer = cart.Customer,
                CustomerId = cart.CustomerId,
                Quantity = cart.Quantity,
                TotalAmount = cart.TotalAmount,
            };

            return cartDto;
        }
        public static List<CartDto> ToDto(this List<Cart> carts)
        {
            var cartsDto = new List<CartDto>();
            foreach (var cart in carts) 
                cartsDto.Add(cart.ToDto());

            return cartsDto;
        }
        public static Cart FromDto(this CartDto cartDto)
        {
            var cart = new Cart(cartDto.CustomerId);

            return cart;
        }
        public static List<Cart> FromDto(this List<CartDto> cartsDto)
        {
            var carts = new List<Cart>();
            foreach(var cart in cartsDto)
                carts.Add(new Cart(cart.CustomerId));

            return carts;
        }
    }
}
