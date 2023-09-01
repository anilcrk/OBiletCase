using OBiletCase.Domain.Models.RequestModels;
using OBiletCase.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.ApiClientAdapter.Interfaces
{
    public interface IOBiletApiClient
    {
        Task<BaseResponse<List<BusLocationResponse>>> GetBusLocations(BaseRequest<string> requestModel);
    }
}
