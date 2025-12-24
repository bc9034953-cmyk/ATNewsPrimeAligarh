using ATNewsprimeApp.DbContent;
using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ATNewsprimeApp.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> GenerateToken([FromBody] AuthloginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return BadRequest(new { Status = false, Message = "Email or Password cannot be empty" });

            var response = await _authService.GenerateToken(request);

            if (!response.Status)
                return BadRequest(response);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("admin/Profile")]

        public async Task<IActionResult> GetProfile()
        {

            var adminid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var profile = await _authService.getProfile(adminid);
            if (profile == null)
                return BadRequest("Admin Not Found");
            return Ok(profile);
        }


    }
}
