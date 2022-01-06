using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Identity;
using Microsoft.AspNetCore.Components.Forms;

namespace CryptoChronos.Shared.Services
{
    public interface IUserService
    {
        public Task<User[]> GetAllUsers();
        public Task<User> GetUser(string address);
        public Task CreateUser(User user);
        public Task EditUser(User user);
        public Task AddUserToRole(AddUserToRoleModel model);
        public Task<List<Role>> GetUserRoles(string address);
        public Task<bool> IsInRole(string role, string address);
        public Task SaveUserProfilePicture(IBrowserFile file, string address);
    }
}