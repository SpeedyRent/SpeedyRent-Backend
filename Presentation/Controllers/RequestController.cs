using Login_back.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Login_back.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Login_back.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly RequestRepository _requestRepository;

        public RequestController(RequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddRequest([FromBody] Request newRequest)
        {
            if (string.IsNullOrEmpty(newRequest.TenantId))
            {
                return BadRequest(new { message = "TenantId es requerido" });
            }

            await _requestRepository.AddAsync(newRequest);
            await _requestRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(AddRequest), new { message = "Solicitud de alquiler creada exitosamente", request = newRequest });
        }
    }
}