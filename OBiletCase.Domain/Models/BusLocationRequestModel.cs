namespace OBiletCase.Domain.Models
{
    public class BusLocationRequestModel : BaseRequestModel
    {
        public string Query { get; set; }

        public DeviceSessionModel DeviceSession { get; set; }
    }
}
