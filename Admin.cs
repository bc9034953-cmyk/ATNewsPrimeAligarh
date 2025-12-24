namespace ATNewsprimeApp.Entitys
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string    PhoneNumber { get; set; }
        public string Role { get; set; } = "admin";
        public DateTime CreatedAt { get; set; }
    }
}
