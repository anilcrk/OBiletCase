using OBiletCase.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Services.Interfaces
{
    public interface IBusLocationService
    {
        public Task<List<SelectListItemDTO>> GetBusLoacations(string searchValue, DateTime date);
    }
}
