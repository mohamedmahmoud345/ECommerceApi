using System;
using Core.Enums;

namespace Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<bool> ProcessPaymentAsync(decimal amount, PaymentMethod paymentMethod);
    }
}
