using ATNewsprimeApp.DbContent;
using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;
using ATNewsprimeApp.DtoResponse.Dtos;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ATNewsprimeApp.Service
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthloginResponse> GenerateToken(AuthloginRequest request)
        {
            var admin = await _context.AllAdmins
                 .FirstOrDefaultAsync(a => a.Email == request.Email);

            if (admin == null || !BCrypt.Net.BCrypt.Verify(request.Password, admin.PasswordHash))
                return new AuthloginResponse { Status = false, Message = "Invalid email and password" };

            //if (!DuplicateWaitObjectException)
            //    return new AuthloginResponse { Status = false, Message = "invaild Password" };

            //bool test = BCrypt.Net.BCrypt.Verify("SharadSDS@123", "$2a$11$z4AQjmS7IomPVHfLtC9FB.uijP3xJqVGR87bXJDAIo/uq8NLrA8l6");



            // Token generate
            var token = GenerateJwtToken(admin);

            return new AuthloginResponse
            {
                Status = true,
                Message = "Login successful",
                token = token,
                ExpiresIn = 3600, // 1 hour
                Admin = new AdminDto
                {
                    Id = admin.Id,
                    Name = admin.Name,
                    Email = admin.Email,
                    Role = admin.Role
                }
            };
        }

        public async Task<AdminProfileResponse> getProfile(int adminid)
        {
            var admin = await _context.AllAdmins.FirstOrDefaultAsync(e => e.Id == adminid);
            if (admin == null)
                return null;
            return new AdminProfileResponse
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Role = admin.Role
            };
        }

        private string GenerateJwtToken(Admin admin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new Claim(ClaimTypes.Name, admin.Name),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Role, admin.Role)
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
