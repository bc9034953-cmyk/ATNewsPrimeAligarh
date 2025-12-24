using System.ComponentModel.DataAnnotations.Schema;

namespace ATNewsprimeApp.Entitys
{
    [Table("PasswordReset")]
    public class Password
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string Otp { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsUsed { get; set; }
    }
}
