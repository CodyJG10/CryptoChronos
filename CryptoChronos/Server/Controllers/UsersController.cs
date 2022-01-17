#nullable disable

using CryptoChronos.Server.Data;
using CryptoChronos.Server.Services;
using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoChronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ProfilePictureService _profilePictureService;
        public UsersController(ApplicationDbContext context, ProfilePictureService profilePictureService)
        {
            _context = context;
            _profilePictureService = profilePictureService;
        }

        [HttpGet("AllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            => await _context.Users.ToListAsync();

        [HttpGet("User/{address}")]
        public ActionResult<User> GetUser(string address)
        {
            var user = _context.Users.SingleOrDefault(x => x.Address.ToLower() == address.ToLower());

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("EditUser")]
        public async Task<IActionResult> PutUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("CreateUser")]
        public async Task PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("AddToRole")]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleModel model)
        {
            var user = _context.Users.Single(x => x.Address.ToLower() == model.UserAddress.ToLower());
            var role = _context.Roles.Single(x => x.Name.ToLower() == model.RoleName.ToLower());
            var userRoles = GetUserRoles(model.UserAddress);
            if (userRoles.Any(x => x.Name.ToLower() == model.RoleName.ToLower()))
                return BadRequest("User is already in role");
            UserRoleClaims claim = new UserRoleClaims()
            {
                Role = role,
                User = user
            };
            if (user.RoleClaims == null)
                user.RoleClaims = new List<UserRoleClaims>();
            user.RoleClaims.Add(claim);
            await _context.SaveChangesAsync();
            return Ok("Succesfully added role claim for user");
        }

        //TODO Configure model configuration in EF
        [HttpGet("GetRoles")]
        public List<Role> GetUserRoles(string address)
        {
            var roles = new List<Role>();
            if (_context.Users.Any(x => x.Address.ToLower() == address.ToLower()))
            {
                var user = _context.Users.Single(x => x.Address.ToLower() == address.ToLower());
                roles = (from userRoleClaim in _context.UserRoleClaims
                         where userRoleClaim.UserId == user.Id
                         let role = _context.Roles.Single(x => x.Id == userRoleClaim.RoleId)
                         select role).ToList();
            }
            return roles;
        }

        [HttpPost("UploadProfilePicture")]
        public async Task<IActionResult> UploadProfilePicture(UploadProfilePictureModel model)
        {
            var user = _context.Users.Single(x => x.Address.ToLower() == model.UserAddress.ToLower());
            var stream = new MemoryStream(model.Data);
            var pictureUri = await _profilePictureService.UploadProfilePicture(model.UserAddress, stream);
            user.ProfilePictureUri = pictureUri.ToString();
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(pictureUri);
        }
    }
}