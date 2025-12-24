using ATNewsprimeApp.DbContent;
using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;
using ATNewsprimeApp.DtoResponse.Dtos;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.EntityFrameworkCore;

namespace ATNewsprimeApp.Service
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDto> CreateAdminAsync(CretaeAdminRequest request)
        {
            var exists = await _context.AllAdmins.AnyAsync(a => a.Email == request.Email);
            if (exists)
                throw new Exception("Admin with this `Email already exists.");

            var admin = new Admin
            {

                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "admin",
                CreatedAt = DateTime.UtcNow
            };

            await _context.AllAdmins.AddAsync(admin);
            await _context.SaveChangesAsync();

            return new AdminDto { Name = admin.Name, Email = admin.Email };
        }

        public async Task<AdminDto> GatAdminByIdAsync(int id)
        {
           var admin=await _context.AllAdmins.FirstOrDefaultAsync(a => a.Id == id);
            if (admin == null)
            
                throw new Exception("Admin Not Found!");

            return new AdminDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Role = admin.Role,

            };
        }

        public async Task<List<AdminDto>> GetAllAdminsAsync()
        {
            return await _context.AllAdmins
       .Select(a => new AdminDto
       {
           Id = a.Id,
           Name = a.Name,
           Email = a.Email,
           Role = a.Role
       })
       .ToListAsync();

        }
    }
}
