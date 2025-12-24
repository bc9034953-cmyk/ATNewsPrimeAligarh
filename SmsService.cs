using System.Web;

namespace ATNewsprimeApp.Service
{
    public class SmsService 
    {

        private readonly string authKey = "482485AMqtMCQkM1an693bafb1P1";
        //private readonly string senderId = "SENDERID"; 
        //private readonly string route = "4";

        public async Task<bool> SandOtpAsync(string phoneNumber, string otp)
        {
            using (var client = new HttpClient())
            {
                string senderId = "ATNEWS";
                string message = $"Your OTP is {otp}";
                string url = $"https://api.msg91.com/api/v5/otp?template_id=YOUR_TEMPLATE_ID&mobile={phoneNumber}&authkey={"482485AMqtMCQkM1an693bafb1P1"}&message={HttpUtility.UrlEncode(message)}&otp={otp}";

                var response = await client.GetAsync(url);

                return response.IsSuccessStatusCode;
            }
        }
    }
}
