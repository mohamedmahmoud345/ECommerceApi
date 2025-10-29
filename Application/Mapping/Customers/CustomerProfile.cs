
using Application.Features.Customers.Response;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Customers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetCustomerByIdResponse>();
        }
    }
}
