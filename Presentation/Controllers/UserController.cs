using Login_back.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Login_back.Infrastructure.Repositories;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
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
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User updatedUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Id = updatedUser.Id;
            existingUser.DniImage = updatedUser.DniImage;
            existingUser.Password = updatedUser.Password;
            existingUser.Phone = updatedUser.Phone;
            existingUser.PhotoUser = updatedUser.PhotoUser;
            existingUser.DriverLicense = updatedUser.DriverLicense;

            _userRepository.Update(existingUser);
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "Usuario actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
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
