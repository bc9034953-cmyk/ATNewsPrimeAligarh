using ATNewsprimeApp.DtoResponse.Dtos;

namespace ATNewsprimeApp.DtoResponse
{
    public class AuthloginResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string token { get; set; }
        public int ExpiresIn { get; set; }
        public AdminDto Admin { get; set; }

    }
}
