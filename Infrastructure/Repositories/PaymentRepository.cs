
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        
        public async Task<Payment> GetByOrderId(Guid OrderId)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.OrderId == OrderId);
        }
        public async Task<Payment> GetByIdAsync(Guid id, bool asNoTracking = false)
        {
            var query = _context.Payments.AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Payment entity)
        {
            _context.Payments.Update(entity);
        }
    }
}
