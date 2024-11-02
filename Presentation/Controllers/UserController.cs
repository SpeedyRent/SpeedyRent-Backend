using Login_back.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Login_back.Infrastructure.Repositories;
using System.Security.Claims;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

      
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var userProfile = new UserProfileDto
            {
                Username = user.Username,
                Email = user.Email
               
            };

            return Ok(userProfile);
        }

        
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto updatedProfile)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            var existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            
            existingUser.Username = updatedProfile.Username;
            existingUser.Email = updatedProfile.Email;
           

            _userRepository.Update(existingUser);
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "Perfil actualizado exitosamente" });
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = updatedUser.Username;
            existingUser.Password = updatedUser.Password;

            _userRepository.Update(existingUser);
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "Usuario actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "Usuario eliminado exitosamente" });
        }
    }
}
