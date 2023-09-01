using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Services.Exceptions;
using OBiletCase.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Services.Services
{
    public class BusLocationService : IBusLocationService
    {
        private readonly IOBiletApiClient _apiClient;

        public BusLocationService(IOBiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<SelectListItemDTO>> GetBusLoacations(string searchValue, DateTime date)
        {
            var response = await _apiClient.GetBusLocations(searchValue, date);

            if(response.Status != ApiClientAdapter.Enums.StatusType.Success)
            {
                throw new BusinessRuleException(response.UserMessage);
            }

            return response.ResponseData.Select(x => new SelectListItemDTO
            {
                Text = x.LongName,
                Value = x.Id.ToString()
            }).ToList();
        }
    }
}
