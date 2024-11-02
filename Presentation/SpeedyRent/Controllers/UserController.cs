
using Domain.SpeedyRent.Model.Commands;
using Domain.SpeedyRent.Model.Queries;
using Domain.SpeedyRent.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SpeedyRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserCommandService _userCommandService;

        public UserController(IUserQueryService userQueryService, IUserCommandService userCommandService)
        {
            _userQueryService = userQueryService;
            _userCommandService = userCommandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _userQueryService.Handle(query);
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _userQueryService.Handle(query);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _userCommandService.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, null);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
        {
            command = command with { Id = id };
            var result = await _userCommandService.Handle(command);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _userCommandService.Handle(command);
            return result ? NoContent() : NotFound();
        }
    }
}
