using System.Text.Json.Serialization;

namespace ATNewsprimeApp.DtoRequest
{
    public class SendOtpRequest
    {
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
