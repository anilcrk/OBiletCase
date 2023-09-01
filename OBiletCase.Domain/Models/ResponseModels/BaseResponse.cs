using Newtonsoft.Json;
using OBiletCase.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models.ResponseModels
{
    public class BaseResponse<T> where T : class
    {
        [JsonProperty("status")]
        public StatusType Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("user-message")]
        public string UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }

        [JsonProperty("client-request-id")]
        public string ClientRequestId { get; set; }

        [JsonProperty("web-correlation-id")]
        public string WebCorrelationId { get; set; }

        [JsonProperty("correlation-id")]
        public string CorrelationId { get; set; }

        [JsonProperty("data")]
        public T ResponseData { get; set; }
    }
}
