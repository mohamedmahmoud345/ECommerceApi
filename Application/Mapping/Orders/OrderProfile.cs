
using Application.Features.Orders.Commands.AddOrder;
using Application.Features.Orders.Common;
using Application.Features.Orders.Queries.GetAllOrdersByCustomerId;
using Application.Features.Orders.Queries.GetByOrderId;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Orders
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderItem, OrderItemResponse>()
                .ForMember(x => x.ProductImage, x => x.MapFrom(x => x.Product.ImageUrl))
                .ForMember(x => x.ProductName, x => x.MapFrom(x => x.Product.Name));

            CreateMap<Order, AddOrderResponse>()
                .ForMember(x => x.OrderItems, x => x.MapFrom(x => x.Items));

            CreateMap<Order, GetAllOrdersByCustomerIdResponse>();

            CreateMap<Order, GetAllOrdersByCustomerIdResponse.Orders>();

            CreateMap<Order, GetByOrderIdResponse>()
                .ForMember(x => x.TotalAmount, x => x.MapFrom(x => x.Items.Sum(x => x.TotalAmount())))
                .ForMember(x => x.OrderItems, x => x.MapFrom(x => x.Items));

            CreateMap<Payment, AddOrderResponse>()
                ;
        }
    }
}
