
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
            _context.Payments.Remove(payment);
        }

        public async Task<Payment?> GetByCustomerIdAsync(Guid cusomterId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.CustomerId == cusomterId);
            var payment = await _context.Payments.FirstOrDefaultAsync(x => x.OrderId == order.Id);
            return payment;
        }

        public async Task<Payment> GetByIdAsync(Guid id)
        { 
            return await _context.Payments.FindAsync(id);
        }

        public async Task Update(Payment entity)
        {
            var payment = await _context.Payments.FindAsync(entity.Id);
            _context.Payments.Update(entity);
        }
    }
}
