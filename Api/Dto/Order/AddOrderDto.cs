using System;
using Core.Entities;
using Core.Enums;

namespace Api.Dto.Order
{
    public record AddOrderDto(Guid CustomerId, PaymentMethod PaymentMethod);
}
