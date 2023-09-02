using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.ParameterObjects
{
    public class BusLocationPO
    {
        public string SearchValue { get; set; }
        public SessionPO SessionInfo { get; set; }
        public DateTime Date { get; set; }
    }
}
