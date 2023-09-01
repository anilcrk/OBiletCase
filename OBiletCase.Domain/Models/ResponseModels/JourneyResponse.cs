using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models.ResponseModels
{
    public class JourneyResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("partner-id")]
        public int PartnerId { get; set; }

        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty("route-id")]
        public string RouteId { get; set; }

        [JsonProperty("bus-type")]
        public string BusType { get; set; }

        [JsonProperty("total-seats")]
        public int TotalSeats { get; set; }

        [JsonProperty("available-seats")]
        public int AvaiableSeats { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime Arrival { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("duration")]
        public TimeSpan Duration { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("internet-price")]
        public decimal InternetPrice { get; set; }

        [JsonProperty("bus-name")]
        public string BusName { get; set; }

        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty("is-active")]
        public bool IsActive { get; set; }

        [JsonProperty("origin-location-id")]
        public int OriginLocationId { get; set; }

        [JsonProperty("destination-location-id")]
        public int DestinationLocationId { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("cancellation-offset")]
        public int CAncellationOffset { get; set; }

        [JsonProperty("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonProperty("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }

        [JsonProperty("display-offset")]
        public TimeSpan DisplayOffset { get; set; }

    }
}
