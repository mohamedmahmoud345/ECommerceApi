using System;
using Application.Features.Payments.Commands.ProcessPayment;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Payments
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, ProcessPaymentResponse>();
        }
    }
}
