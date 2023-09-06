using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.DataTransferObjects
{
    public class BusJourneyDTO
    {
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        public decimal InternetPrice { get; set; }
        public string Currency { get; set; }
    }
}
