using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Motel.Application.Category.User;
using Motel.ViewModel.System.User;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace Motel.BackEndApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.Authentication(request);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("????");
            }
            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.register(register);
            if (result)
                return Ok();
            return BadRequest("Register is unsuccessful");
        }
    }
}
