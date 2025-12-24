using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;
using ATNewsprimeApp.Entitys;

namespace ATNewsprimeApp.IService
{
    public interface IAuthService
    {
        Task<AuthloginResponse> GenerateToken(AuthloginRequest request);
        Task<AdminProfileResponse> getProfile(int adminid);
    }
}
