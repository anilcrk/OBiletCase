using Newtonsoft.Json;

namespace OBiletCase.Domain.Models.ResponseModels
{
    public class SessionResponse
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
