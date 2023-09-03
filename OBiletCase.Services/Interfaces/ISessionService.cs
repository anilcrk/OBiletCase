using OBiletCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Services.Interfaces
{
    public interface ISessionService
    {
        public Task<DeviceSessionModel> GetDeviceSession(SessionRequestModel request);
    }
}
