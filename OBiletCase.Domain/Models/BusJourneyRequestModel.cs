using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models
{
    public class BusJourneyRequestModel : BaseRequestModel
    {
        public string OriginId { get; set; }
        public string DestinationId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DeviceSessionModel DeviceSession { get; set; }
    }
}
