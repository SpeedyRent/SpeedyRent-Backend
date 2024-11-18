using System.Security.Claims;
using Login_back.Domain.Model;
using Login_back.Infrastructure.Repositories;
using Login_back.Presentation.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly OwnerRepository _ownerRepository;

        public VehicleController(VehicleRepository vehicleRepository, OwnerRepository ownerRepository)
        {
            _vehicleRepository = vehicleRepository;
            _ownerRepository = ownerRepository;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleDto vehicleDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "Usuario no autenticado" });
            }

            var owner = await _ownerRepository.GetByUserIdAsync(userId);
            if (owner == null)
            {
                return BadRequest(new { message = "El usuario no tiene un perfil de propietario" });
            }

            var newVehicle = new Vehicle
            {
                Id = Guid.NewGuid().ToString(),
                Brand = vehicleDto.Brand,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Rate = vehicleDto.Rate,
                Description = vehicleDto.Description,
                Location = vehicleDto.Location,
                Photos = vehicleDto.Photos,
                OwnerId = owner.Id
            };

            await _vehicleRepository.AddAsync(newVehicle);
            await _vehicleRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(AddVehicle), new { message = "Vehículo registrado exitosamente", vehicle = newVehicle });
        }
        


    }
}