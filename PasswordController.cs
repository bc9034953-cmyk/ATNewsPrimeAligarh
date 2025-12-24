using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATNewsprimeApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            this.passwordService = passwordService;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtpAsync([FromBody] SendOtpRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
                return BadRequest("Phone number cannot be empty");

            bool status = await passwordService.SandOtpAsync(request.PhoneNumber);

            return Ok(new
            {
                success = status,
                message = "OTP sent successfully."
            });
        }



        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpRequest request)
        {
            var result = await passwordService.VerifyOtpAsync(request.PhoneNumber, request.Otp);
            return Ok(new { success = result });
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var result = await passwordService.ResetPasswordAsync(request.PhoneNumber, request.NewPassword);
            return Ok(new { success = result });
        } 
    }
}
