﻿
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Review entity)
        {
            await _context.Reviews.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if(review != null) 
                _context.Reviews.Remove(review);
        }

        public async Task<List<Review>?> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Reviews.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<List<Review>?> GetByProductIdAsync(Guid productId)
        {
            var reviews = await _context.Reviews.Where(x => x.ProductId == productId).ToListAsync();

            return reviews;
        }

        public async Task Update(Review entity)
        {
            _context.Reviews.Update(entity);
        }
    }
}
