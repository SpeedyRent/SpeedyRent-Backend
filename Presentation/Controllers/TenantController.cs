using Login_back.Domain.Model;
using Login_back.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly TenantRepository _tenantRepository;

        public TenantController(TenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        // Add CRUD endpoints here
    }
}