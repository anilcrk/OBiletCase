using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models.ResponseModels
{
    public class Stop
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kolayCarLocationId")]
        public string LocationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station")]
        public int Station { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }
}
