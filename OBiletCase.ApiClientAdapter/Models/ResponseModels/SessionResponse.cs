using Newtonsoft.Json;

namespace OBiletCase.ApiClientAdapter.Models.ResponseModels
{
    public class SessionResponse
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
