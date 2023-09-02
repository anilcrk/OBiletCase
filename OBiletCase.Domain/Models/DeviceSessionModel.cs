using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models
{
    public class DeviceSessionModel : BaseResponseModel
    {
        public string SessionId { get; set; }
        public string DeviceId { get; set; }
    }

    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public string ErrorExplanation { get; set; }
    }
}
