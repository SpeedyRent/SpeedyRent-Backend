using Login_back.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Login_back.Infrastructure.Repositories;
using Login_back.Presentation.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly OwnerRepository _ownerRepository;
        private readonly TenantRepository _tenantRepository;
        private readonly IConfiguration _configuration;


        public AuthController(
            UserRepository userRepository,
            OwnerRepository ownerRepository,
            TenantRepository tenantRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _ownerRepository = ownerRepository;
            _tenantRepository = tenantRepository;
            _configuration = configuration;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var users = await _userRepository.GetAllAsync();
            var validUser = users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (validUser == null)
            {
                return Unauthorized(new { message = "Correo o contraseña incorrectos" });
            }

            return Ok(new { message = "Inicio de sesión exitoso", user = validUser });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var users = await _userRepository.GetAllAsync();
            var existingUser = users.FirstOrDefault(u => u.Email == registerDto.Email);

            if (existingUser != null)
            {
                return Conflict(new { message = "El correo ya está registrado" });
            }

            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Dni = registerDto.Dni,
                DniImage = registerDto.DniImage,
                Name = registerDto.Name,
                Phone = registerDto.Phone,
                PhotoUser = registerDto.PhotoUser,
                Email = registerDto.Email,
                Password = registerDto.Password,
                DriverLicense = registerDto.DriverLicense
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            var newOwner = new Owner
            {
                Id = Guid.NewGuid().ToString(),
                OwnerUserId = newUser.Id
            };
            await _ownerRepository.AddAsync(newOwner);

            var newTenant = new Tenant
            {
                Id = Guid.NewGuid().ToString(),
                TenantUserId = newUser.Id
            };
            await _tenantRepository.AddAsync(newTenant);

            await _ownerRepository.SaveChangesAsync();
            await _tenantRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Register), new { message = "Usuario registrado exitosamente", user = newUser });
        }
        
        [HttpPost("generate-token")]
        public async Task<IActionResult> GenerateToken([FromBody] LoginDto loginDto)
        {
            var users = await _userRepository.GetAllAsync();
            var validUser = users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (validUser == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, validUser.Id),
                new Claim(ClaimTypes.Email, validUser.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }
}
