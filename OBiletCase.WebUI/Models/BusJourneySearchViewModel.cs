using OBiletCase.WebUI.Filters;
using System.ComponentModel.DataAnnotations;

namespace OBiletCase.WebUI.Models
{
    public class BusJourneySearchViewModel
    {
        public string OriginId { get; set; }

        public string DestinationId { get; set; }

        public string OriginName { get; set; }

        public string DestionationName { get; set; }

        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(1).Date;
    }
}
