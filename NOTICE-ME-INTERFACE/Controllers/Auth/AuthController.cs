using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NOTICE_ME_CROSSCUTING.DTO.Auth;
using NOTICE_ME_SERVICE.ApplicationService.Auth.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace NOTICE_ME_INTERFACE.Controllers.Auth
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplicationService applicationService;

        public AuthController(IAuthApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [SwaggerResponse(statusCode: 200, description: "Login Success", Type = typeof(LoginResponseDto))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto) => Ok(await applicationService.Login(dto));


        [SwaggerResponse(statusCode: 200, description: "Register Success")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            await applicationService.Register(dto);
            return Ok();
        }

    }
}
