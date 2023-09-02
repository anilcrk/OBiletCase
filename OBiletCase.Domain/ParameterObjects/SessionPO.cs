using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.ParameterObjects
{
    public class SessionPO
    {
        public int Type { get; set; } = 1;
        public ConnectionPO Connection { get; set; }
        public BrowserPO Browser { get; set; }
    }
}
