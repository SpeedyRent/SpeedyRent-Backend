using Login_back.Domain.Model;
using Login_back.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleController(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // Add CRUD endpoints here
    }
}