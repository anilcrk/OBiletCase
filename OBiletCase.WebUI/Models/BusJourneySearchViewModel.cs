using OBiletCase.WebUI.Filters;
using System.ComponentModel.DataAnnotations;

namespace OBiletCase.WebUI.Models
{
    public class BusJourneySearchViewModel
    {
        [Display(Name = "Nereden")]
        [Required(ErrorMessage = "{0} Gerekli!")]
        [DifferentFrom(nameof(DestinationId))]
        public string OriginId { get; set; }

        [Display(Name = "Nereye")]
        [Required(ErrorMessage = "{0} Gerekli!")]
        public string DestinationId { get; set; }

        [Display(Name = "Tarih")]
        [Required(ErrorMessage = "{0} Gerekli!")]
        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(1).Date;
    }
}
