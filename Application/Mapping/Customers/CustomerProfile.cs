using Application.Features.Customers.Queries.GetCustomerById;
using AutoMapper;
using Core.Entities;
using Application.Features.Customers.Queries.GetAllCustomers;
using Application.Features.Customers.Commands.UpdateCustomer;

namespace Application.Mapping.Customers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetCustomerByIdResponse>();
            CreateMap<Customer, GetAllCustomersResponse>();
        }
    }
}
