using Login_back.Domain.Model;
using Login_back.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerRepository _ownerRepository;

        public OwnerController(OwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        // Add CRUD endpoints here
    }
}