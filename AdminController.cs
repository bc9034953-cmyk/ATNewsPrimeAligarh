using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATNewsprimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [Authorize]
        [HttpPost("CretaeAdmin")]

        public async Task<IActionResult> CreateAdminAsync([FromBody] CretaeAdminRequest request)
        {
            var add=await _adminService.CreateAdminAsync(request);
            return Ok(add);
        }


        [HttpGet("GatAdminById/{id}")]


        public async Task<IActionResult> GatAdminByIdAsync(int id)
        {
            var admin=await _adminService.GatAdminByIdAsync(id);
            return Ok(admin);
        }

        [Authorize]
        [HttpGet("GatAllAdmin")]

        public async Task<IActionResult> GetAllAdminsAsync()
        {
            var all=await  _adminService.GetAllAdminsAsync();
            return Ok(all);
        }
    }
}
