using OBiletCase.Domain.ParameterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models
{
    public class BusLocationRequestModel
    {
        public string SearchValue { get; set; }
        public DeviceSessionModel DeviceSession { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
    }
}
