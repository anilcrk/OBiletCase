using OBiletCase.Domain.DataTransferObjects;

namespace OBiletCase.WebUI.Models
{
    public class BusJourneyDetailViewModel
    {
        public string DepartureDateText { get; set; }
        public string FormHeaderText { get; set; }

        public List<BusJourneyDTO> BusJourneys { get; set; }
    }
}
