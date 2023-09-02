using OBiletCase.Domain.ParameterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Models
{
    public class SessionRequestModel
    {
        public int Type { get; set; }
        public ConnectionPO Connection { get; set; }
        public BrowserPO Browser { get; set; }
    }
}
