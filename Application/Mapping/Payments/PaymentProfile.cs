using System;
using Application.Features.Payments.Commands.ProcessPayment;
using Application.Features.Payments.Queries.GetByCustomerId;
using Application.Features.Payments.Queries.GetById;
using Application.Features.Payments.Queries.GetPaymentByOrderId;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Payments
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, ProcessPaymentResponse>();

            CreateMap<Payment, GetPaymentByOrderIdResponse>();

            CreateMap<Payment, GetByCustomerIdResponse>();

            CreateMap<Payment, GetByIdResponse>();
        }
    }
}
