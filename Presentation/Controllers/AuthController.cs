using Login_back.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Login_back.Infrastructure.Repositories;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public AuthController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            var users = await _userRepository.GetAllAsync();
            var validUser = users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

            if (validUser == null)
            {
                return Unauthorized();
            }

            return Ok("Login successful!");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            var users = await _userRepository.GetAllAsync();
            var existingUser = users.FirstOrDefault(u => u.Username == newUser.Username);

            if (existingUser != null)
            {
                return Conflict(new { message = "El nombre de usuario ya existe" });
            }

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync(); // Línea para guardar cambios en la base de datos.

            return CreatedAtAction(nameof(Register), new { message = "Usuario registrado exitosamente" });
        }
    }
}