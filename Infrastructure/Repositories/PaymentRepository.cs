
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Payment entity)
        {
            await _context.Payments.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null) 
                _context.Payments.Remove(payment);
        }

        public async Task<Payment?> GetByCustomerIdAsync(Guid customerId)
        {
            var payment = await _context.Payments
                    .Include(p => p.Order)
                    .Where(p => p.Order.CustomerId == customerId)
                    .FirstOrDefaultAsync();
            return payment;
        }

        public async Task<Payment> GetByIdAsync(Guid id)
        { 
            return await _context.Payments.FindAsync(id);
        }

        public async Task Update(Payment entity)
        {
            _context.Payments.Update(entity);
        }
    }
}
