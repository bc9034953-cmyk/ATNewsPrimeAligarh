using ATNewsprimeApp.Entitys;

namespace ATNewsprimeApp.IService
{
    public interface IPasswordService
    {
        Task<bool> SandOtpAsync(string PhoneNumber);
        Task<bool> VerifyOtpAsync(string phoneNumber, string otp);
        Task<bool> ResetPasswordAsync(string phoneNumber, string newPassword);
    }
}
