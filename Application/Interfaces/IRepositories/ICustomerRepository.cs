
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByIdAsync(Guid id);
        Task Update(Customer entity);
        Task<Customer> AddAsync(Customer entity);
        Task DeleteAsync(Guid id);
    }
}
