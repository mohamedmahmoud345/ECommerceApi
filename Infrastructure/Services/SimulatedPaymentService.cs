using System;
using Application.Interfaces.Services;
using Core.Enums;

namespace Infrastructure.Services
{
    public class SimulatedPaymentService : IPaymentService
    {        
        public Task<bool> ProcessPaymentAsync(decimal amount, PaymentMethod paymentMethod)
        {
            var random = new Random();
            var success = Random.Shared.Next(0, 100) < 90; // 90% success
            return Task.FromResult(success);
        }
    }
}
