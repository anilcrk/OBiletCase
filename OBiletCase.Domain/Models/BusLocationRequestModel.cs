namespace OBiletCase.Domain.Models
{
    public class BusLocationRequestModel
    {
        public string Query { get; set; }
        public string Language { get; set; }

        public DeviceSessionModel DeviceSession { get; set; }
    }
}
