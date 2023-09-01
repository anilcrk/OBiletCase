using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models.RequestModels
{
    public class BaseRequest<T> where T : class
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
    }
}
