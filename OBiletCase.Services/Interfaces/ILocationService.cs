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
        /// <summary>
        /// Returns the bus location list as SelectListItemDTO according to the incoming model
        /// </summary>
        /// <param name="request">The request model containing criteria for bus location search.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of bus locations</returns>
        public Task<List<SelectListItemDTO>> GetBusLoacations(BusLocationRequestModel request);
    }
}
