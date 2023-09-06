using System.ComponentModel.DataAnnotations;

namespace OBiletCase.WebUI.Models
{
    public class BusJourneySearchViewModel
    {
        [Display(Name ="Nereden")]
        public string OriginId { get; set; }

        [Display(Name = "Nereye")]
        public string DestinationId { get; set; }

        public string OriginName { get; set; }

        public string DestionationName { get; set; }

        [Display(Name = "Tarih")]
        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(1).Date;
    }
}
