using System;
using Application.Interfaces.Services;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userMang;
        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userMang = userManager;
        }
        public async Task<(bool Success, Guid UserId, string Error)> RegisterUserAsync(string email, string userName, string password)
        {
            var existingUser = await _userMang.FindByEmailAsync(email);
            if (existingUser != null)
                return (false, Guid.Empty, "Email Already Exist");

            var user = new ApplicationUser()
            {
                Email = email,
                UserName = userName
            };
            await _userMang.AddToRoleAsync(user, "Customer");
            var result = await _userMang.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, Guid.Empty, errors);
            }



            return (true, user.Id, string.Empty);
        }
        public async Task<(bool Success, Guid UserId, string UserName, string Error)> LoginAsync(string email, string password)
        {
            var existingUser = await _userMang.FindByEmailAsync(email);
            if (existingUser == null)
                return (false, Guid.Empty, string.Empty, "User Not Exist please Register");

            var result = await _userMang.CheckPasswordAsync(existingUser, password);
            if (!result)
                return (false, Guid.Empty, string.Empty, "Wrong Password");


            return (true, existingUser.Id, existingUser.UserName, string.Empty);
        }
        public async Task<IList<string>> GetUserRolesAsync(Guid userId)
        {
            var user = await _userMang.FindByIdAsync(userId.ToString());
            if (user == null)
                return new List<string>();

            return await _userMang.GetRolesAsync(user);
        }
    }
}
