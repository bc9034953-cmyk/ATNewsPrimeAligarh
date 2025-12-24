using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse.Dtos;

namespace ATNewsprimeApp.IService
{
    public interface IAdminService
    {
        Task<AdminDto> CreateAdminAsync(CretaeAdminRequest request);
        Task<AdminDto> GatAdminByIdAsync(int id);
        Task<List<AdminDto>> GetAllAdminsAsync();
    }
}
