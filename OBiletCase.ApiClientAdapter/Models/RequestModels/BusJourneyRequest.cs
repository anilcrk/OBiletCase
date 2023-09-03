using Newtonsoft.Json;

namespace OBiletCase.ApiClientAdapter.Models.RequestModels
{
    public class BusJourneyRequest
    {
        [JsonProperty("origin-id")]
        public string OriginId { get; set; }

        [JsonProperty("destination-id")]
        public string DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}
