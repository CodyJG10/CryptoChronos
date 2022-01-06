using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Identity;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace CryptoChronos.Shared.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task CreateUser(User user)
            => await _httpClient.PostAsJsonAsync("CreateUser", user);
        public async Task<User[]> GetAllUsers()
            => await _httpClient.GetFromJsonAsync<User[]>("AllUsers");
        public async Task<User> GetUser(string address)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<User>("User/" + address.ToLower());
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task EditUser(User user)
        {
            var result = await _httpClient.PutAsJsonAsync("EditUser", user);
            Console.WriteLine(result);
        }

        public async Task AddUserToRole(AddUserToRoleModel model)
            => await _httpClient.PostAsJsonAsync("AddToRole", model);

        public async Task<List<Role>> GetUserRoles(string address)
           => await _httpClient.GetFromJsonAsync<List<Role>>("GetRoles?address=" + address) ?? null;

        public async Task<bool> IsInRole(string role, string address)
        {
            try
            {
                var roles = await GetUserRoles(address);
                if (roles != null)
                {
                    return roles.Any(x => x.Name.ToLower() == role.ToLower());
                }
            }
            catch (Exception) { }
            return false;
        }

        public async Task SaveUserProfilePicture(IBrowserFile file, string address)
        {
            using (var stream = file.OpenReadStream(maxAllowedSize: 5000000))
            {
                MemoryStream memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                UploadProfilePictureModel model = new UploadProfilePictureModel()
                {
                    UserAddress = address,
                    Data = memoryStream.ToArray()
                };
                await _httpClient.PostAsJsonAsync("UploadProfilePicture", model);
            }
        }
    }
}