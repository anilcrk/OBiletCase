using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Domain.Enums
{
    public enum StatusType
    {
        Success,
        InvalidDepartureDate,
        InvalidRoute,
        InvalidLocation,
        Timeout
    }
}
