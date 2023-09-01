using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models.RequestModels
{
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }
    }
}
