
using Application.Interfaces.IRepositories;
using Core.Entities;
using Core.Enums;
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
        public async Task<Payment> AddAsync(Payment entity)
        {
            var payment = await _context.Payments.AddAsync(entity);
            return payment.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null) 
                _context.Payments.Remove(payment);
        }

        public async Task<Payment?> GetByCustomerIdAsync(Guid customerId)
        {
            var payment = await _context.Payments.AsNoTracking()
                    .Include(p => p.Order)
                    .Where(p => p.Order.CustomerId == customerId)
                    .FirstOrDefaultAsync();
            return payment;
        }

        public async Task<Payment> GetByIdAsync(Guid id)
        { 
            return await _context.Payments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Payment entity)
        {
            _context.Payments.Update(entity);
        }
    }
}
