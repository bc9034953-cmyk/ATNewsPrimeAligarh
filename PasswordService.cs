using ATNewsprimeApp.DbContent;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ATNewsprimeApp.Service
{
    public class PasswordService : IPasswordService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClient;        

        public PasswordService(ApplicationDbContext context, IHttpClientFactory httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }


        public async Task<bool> ResetPasswordAsync(string phoneNumber, string newPassword)
        {
            var user = await _context.AllAdmins.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null) return false;


            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> SandOtpAsync(string phoneNumber)
        {

            string dbPhone = phoneNumber.StartsWith("91")
                ? phoneNumber
                : "91" + phoneNumber;

            string smsPhone = phoneNumber.Length > 10
                ? phoneNumber.Substring(phoneNumber.Length - 10)
                : phoneNumber;

            string otp = new Random().Next(100000, 999999).ToString();

            var entry = new Password
            {
                PhoneNumber = dbPhone,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            _context.PasswordReset.Add(entry);
            await _context.SaveChangesAsync();

            try
            {
                var client = _httpClient.CreateClient();
                client.DefaultRequestHeaders.Add("authkey", "482485AMqtMCQkM1an693bafb1P1");

                var payload = new
                {
                    template_id = "693a9fd4033261590a721c06",
                    mobile = smsPhone,
                };

                var json = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(payload),
                    Encoding.UTF8,
                    "application/json" 
                );

                var response = await client.PostAsync(
                    "https://api.msg91.com/api/v5/otp",
                    json
                );

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("MSG91 Response:" + result);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine("SMS sending failed: " + ex.Message);

                return false;
            }

            return true;
        }


        public async Task<bool> VerifyOtpAsync(string phoneNumber, string otp)
        { 
            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(otp))
                return false;

            var record = await _context.PasswordReset
                .Where(x => x.PhoneNumber == phoneNumber && x.Otp == otp && !x.IsUsed)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (record == null || record.ExpiryTime < DateTime.UtcNow)
                return false;

            record.IsUsed = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
