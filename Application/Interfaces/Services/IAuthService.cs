using System;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<(bool Success, Guid UserId, string Error)> RegisterUserAsync(string email, string userName, string password);
        Task<(bool Success, Guid UserId, string UserName, string Error)> LoginAsync(string email, string password);
        Task<IList<string>> GetUserRolesAsync(Guid userId);
    }
}
