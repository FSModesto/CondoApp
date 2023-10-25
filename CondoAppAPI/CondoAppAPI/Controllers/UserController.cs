using Domain.Interfaces.Services;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("logins")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest model)
        {
            return await _service.Login(model);
        }
    }
}