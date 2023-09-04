using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<List<SelectListItemDTO>> GetBusLoacations(BusLocationRequestModel request);
    }
}
