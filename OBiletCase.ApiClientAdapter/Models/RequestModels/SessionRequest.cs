using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.ApiClientAdapter.Models.RequestModels
{
    public class SessionRequest
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("browser")]
        public Browser Browser { get; set; }
    }
}
