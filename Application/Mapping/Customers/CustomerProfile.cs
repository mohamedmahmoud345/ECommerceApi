
using Application.Features.Customers.Queries.GetCustomerByEmail;
using Application.Features.Customers.Queries.GetCustomerById;
using Application.Features.Customers.Commands.AddCustomer;
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
            CreateMap<Customer, GetCustomerByEmailResponse>();
            CreateMap<AddCustomerCommand, Customer>();
            CreateMap<Customer , AddCustomerResponse>();
            CreateMap<Customer, GetAllCustomersResponse>();
            CreateMap<UpdateCustomerCommand, Customer>();
            
        }
    }
}
