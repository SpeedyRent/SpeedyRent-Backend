using Login_back.Domain.Model;
using Login_back.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        // Add CRUD endpoints here
    }
}