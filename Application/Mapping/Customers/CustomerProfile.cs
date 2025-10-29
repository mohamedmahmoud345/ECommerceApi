
using Application.Features.Customers.Queries.GetCustomerById;
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
