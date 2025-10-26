
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByIdAsync(Guid id);
        void Update(Customer entity);
        Task AddAsync(Customer entity);
        Task DeleteAsync(Guid id);
    }
}
